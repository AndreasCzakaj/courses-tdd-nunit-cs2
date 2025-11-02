using NUnit.Framework;
using NUnit.Framework.Constraints;
using TDD.Uss;


namespace TDD.Tests.Uss
{
    class Book
    {
        public string Name { get; set; } = "";
    }
    
    public class DaoDictionaryImplTests
    {
        private DaoDictionaryImpl<Book> _dao;

        [SetUp]
        public void setUp()
        {
            Dictionary<string, Book> repo = new Dictionary<string, Book>();
            var book = new Book();
            book.Name = "Necronomicon";
            repo.Add("existingKey", book);
            
            _dao = new DaoDictionaryImpl<Book>(repo);
        }
        
        [Test]
        public void itShouldYieldNullForUnknownIdentifier()
        {
            var actual = _dao.Get("i_do_not_exist");
            Assert.That(actual, Is.Null);
        }
        
        [Test]
        public void itShouldYieldEntryForKnownIdentifier()
        {
            var actual = _dao.Get("existingKey");
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual!.Name, Is.EqualTo("Necronomicon"));
            });
            //Assert.That(actual, Is.Not.Null.And.Has.Property("Name").EqualTo("Necronomicon"));
        }
    }
    
    public class DaoFileImplTests
    {
        private DaoFileImpl<Book> _dao;
        private DirectoryInfo dirInfo;
        private string tmpFolder;

        [SetUp]
        public void setUp()
        {
            dirInfo = Directory.CreateTempSubdirectory("tdd-DaoFileImplTests");
            tmpFolder = dirInfo.FullName;
            
            _dao = new DaoFileImpl<Book>(tmpFolder);
            
            var book = new Book();
            book.Name = "Necronomicon";
            _dao.Save(book, "existingKey");
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
        public void itShouldYieldNullForUnknownIdentifier()
        {
            var actual = _dao.Get("i_do_not_exist");
            Assert.That(actual, Is.Null);
        }
        
        [Test]
        public void itShouldYieldEntryForKnownIdentifier()
        {
            var actual = _dao.Get("existingKey");
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual!.Name, Is.EqualTo("Necronomicon"));
            });
            //Assert.That(actual, Is.Not.Null.And.Has.Property("Name").EqualTo("Necronomicon"));
        }
        
        [Test]
        public void itShouldFailForGetIfIOError()
        {
            var filePath = Path.Combine(tmpFolder, "existingKey.json");
            File.WriteAllText(filePath, "this_is_broken_json");
            DaoException error = Assert.Throws<DaoException>(() => _dao.Get("existingKey"));
            Assert.That(error.Message, Is.EqualTo("DaoFileImpl.get failed"));
        }
        
        [Test]
        public void itShouldFailForSaveIfIOError()
        {
            var book = new Book();
            book.Name = "Hitchhiker's Guide to the Galaxy";
            
            Directory.Delete(tmpFolder, true);
            
            DaoException error = Assert.Throws<DaoException>(() => _dao.Save(book, "someKey"));
            Assert.That(error.Message, Is.EqualTo("DaoFileImpl.Save failed"));
        }
    }
}
