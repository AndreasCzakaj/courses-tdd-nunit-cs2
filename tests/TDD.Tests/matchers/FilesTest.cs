using NUnit.Framework;
using System.Collections.Generic;
using TDD.Matchers;

namespace TDD.Tests.Matchers
{
    public class FilesTest
    {
        private string _existingPath;
        private string _existingPath2;
        private string _existingPath3;
        private string _nonExistingPath;
        private string _parentFolder;
        
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
        [Ignore("ToDo")]
        public void TestExisting()
        {
        }

        [Test]
        [Description("expect file at _nonExistingPath not to exist")]
        [Ignore("ToDo")]
        public void TestNonExisting()
        {
        }

        [Test]
        [Description("expect folder at _parentFolder to exists and not to be empty")]
        [Ignore("ToDo")]
        public void TestFolder()
        {
        }

        [Test]
        [Description("expect file at _existingPath to be child of parent folder")]
        [Ignore("ToDo")]
        public void TestParentFolder()
        {
        }

        [Test]
        [Description("expect file at _existingPath2 to have identical content as file at _existingPath but different from file at _existingPath3")]
        [Ignore("ToDo")]
        public void TestFileContent()
        {
        }
    }
}
