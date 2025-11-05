using NUnit.Framework;
using TDD.Misc;

namespace TDD.Tests.Misc
{
    public class DemoTest
    {
        private DirectoryInfo? dirInfo;
        private string? tmpFolder;
        private Demo demo;

        [SetUp]
        public void SetUp()
        {
            dirInfo = Directory.CreateTempSubdirectory("tdd-DemoTest");
            tmpFolder = dirInfo.FullName;
            
            demo = new Demo();
        }

        [TearDown]
        public void tearDown()
        {
            if (Directory.Exists(tmpFolder))
            {
                Directory.Delete(tmpFolder, true);
            }
        }


        [Test]
        public void ExportDatasetShouldFailWhenFilePathIsEmpty()
        {
            var error = Assert.Throws<InvalidOperationException>(() => demo.ExportDataset(string.Empty) );
            Assert.That(error.Message, Is.EqualTo("Cannot export dataset: FilePath is not set"));
        }

        [Test]
        public void ExportDatasetShouldFailWhenSerializerFails()
        {
            /* demo = new Demo() {
                protected override string SerializeRevitPropertiesToJson(Dictionary<string, string> RevitProperties) {
                    throw new Exception("Serialization failed");
                }
            }; */
            demo = new DemoWithFailingSerializer();
            var error = Assert.Throws<InvalidOperationException>(() => demo.ExportDataset("some_path"));
            Assert.That(error.Message, Is.EqualTo("Error exporting dataset: Serialization failed"));
        }

        [Test]
        public void ExportDatasetShouldFailWhenWriteToFileFails()
        {
            demo = new DemoWithFailingFileWriter();
            var error = Assert.Throws<InvalidOperationException>(() => demo.ExportDataset("some_path"));
            Assert.That(error.Message, Is.EqualTo("Error exporting dataset: WriteToFile failed"));
        }

        [Test]
        public void ExportDatasetShouldFailWhenWriteToFileOK()
        {
            // Arrange
            DemoWithFakeFileWriter demoWithFakeFileWriter = new DemoWithFakeFileWriter();
            demo = demoWithFakeFileWriter;
            Assert.That(demoWithFakeFileWriter.collector, Has.Count.EqualTo(0));

            // Act
            demo.ExportDataset("some_path");

            // Assert
            Assert.That(demoWithFakeFileWriter.collector, Has.Count.EqualTo(1));
            Assert.That(demoWithFakeFileWriter.collector, Contains.Item("{\"Author\":\"John Doe\",\"Version\":\"1.0.0\",\"Project\":\"Sample Project\"}"));
        }

        [Test]
        public void BakeFromBrepOk()
        {
            // Arrange                            
            DemoWithFakeBakeScopeElement demoWithFakeBakeScopeElement = new DemoWithFakeBakeScopeElement();
            demo = demoWithFakeBakeScopeElement;
            Assert.That(demoWithFakeBakeScopeElement.collector, Has.Count.EqualTo(0));

            // Act
            demo.BakeFromBrep();

            // Assert
            Assert.That(demoWithFakeBakeScopeElement.collector, Has.Count.EqualTo(1));
            var bakeContext = demoWithFakeBakeScopeElement.collector[0];
            Assert.That(bakeContext.RevProperties, Contains.Key("Author"));
            Assert.That(bakeContext.placingParameters, Contains.Key("host"));
        }
    }

    class DemoWithFailingSerializer : Demo
    {
        protected override string SerializeRevitPropertiesToJson(Dictionary<string, string> RevitProperties)
        {
            throw new Exception("Serialization failed");
        }
    }

    class DemoWithFailingFileWriter : Demo
    {
        protected override void WriteToFile(string filePath, string content)
        {
            throw new Exception("WriteToFile failed");
        }
    }

    class DemoWithFakeFileWriter : Demo
    {
        public List<string> collector = new List<string>();

        protected override void WriteToFile(string filePath, string content)
        {
            collector.Add(content);
        }
    }

    class DemoWithFakeBakeScopeElement : Demo
    {
        public List<BakeContext> collector = new List<BakeContext>();

        protected override void BakeScopeElement(Dictionary<string, string> RevProperties, Dictionary<string, object> placingParameters)
        {
            var item = new BakeContext();
            item.RevProperties = RevProperties;
            item.placingParameters = placingParameters;
            collector.Add(item);
        }
    }

    class BakeContext
    {
        public Dictionary<string, object> placingParameters = new Dictionary<string, object>();
        public Dictionary<string, string> RevProperties = new Dictionary<string, string>();
    }
}