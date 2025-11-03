using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Collections.Generic;
using TDD.Matchers;

namespace TDD.Tests.Matchers
{
    public class FilesTest
    {
        private string _existingPath = "";
        private string _existingPath2 = "";
        private string _existingPath3 = "";
        private string _nonExistingPath = "";
        private string _parentFolder = "";
        
        [SetUp]
        public void Setup()
        {
            var baseDirectory = AppContext.BaseDirectory;
            var projectRoot = Path.Combine(baseDirectory, "../../../../..");
            _parentFolder = Path.Combine(projectRoot, "src/TDD/matchers");
            _existingPath = Path.Combine(_parentFolder, "ppl.json");
            _existingPath2 = Path.Combine(_parentFolder, "ppl2.json");
            _existingPath3 = Path.Combine(_parentFolder, "ppl3.json");
            _nonExistingPath = Path.Combine(projectRoot, "i_do_not_exist.json");
        }

        [Test]
        [Description("expect file at _existingPath to exist")]
        public void TestExisting()
        {
            Assert.That(_existingPath, Does.Exist);
        }

        [Test]
        [Description("expect file at _nonExistingPath not to exist")]
        public void TestNonExisting()
        {
            Assert.That(_nonExistingPath, Does.Not.Exist);
        }

        [Test]
        [Description("expect folder at _parentFolder to exists and not to be empty")]
        public void TestFolder()
        {
            Assert.That(_parentFolder, Does.Exist);
            Assert.That(_parentFolder, Is.Not.Empty);
        }

        [Test]
        [Description("expect file at _existingPath to be child of parent folder")]
        public void TestParentFolder()
        {
            Assert.That(_existingPath, Is.SamePathOrUnder(_parentFolder));
        }

        [Test]
        [Description("expect file at _existingPath2 to have identical content as file at _existingPath but different from file at _existingPath3")]
        public void TestFileContent()
        {
            var content1 = File.ReadAllText(_existingPath);
            var content2 = File.ReadAllText(_existingPath2);
            var content3 = File.ReadAllText(_existingPath3);

            Assert.That(content2, Is.EqualTo(content1));
            Assert.That(content2, Is.Not.EqualTo(content3));
        }
    }
}
