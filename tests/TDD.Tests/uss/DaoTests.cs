using NUnit.Framework;
using NUnit.Framework.Constraints;
using TDD.Uss;


namespace TDD.Tests.Uss
{
    public class Book
    {
        public string Name { get; set; } = "";
    }
    
    public abstract class DaoTestsBase<T> where T : Dao<Book>
    {
        public T _dao;

        public Book _ExistingBook = new Book()
        {
            Name = "Necronomicon"
        };

        protected abstract T CreateAndInitDao();
        
        [SetUp]
        public void SetUp()
        {
            _dao = CreateAndInitDao();
        }
        
        [Test]
        public void ItShouldYieldNullForUnknownIdentifier()
        {
            var actual = _dao.Get("i_do_not_exist");
            Assert.That(actual, Is.Null);
        }
        
        [Test]
        public void ItShouldYieldEntryForKnownIdentifier()
        {
            var actual = _dao.Get("existingKey");
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual!.Name, Is.EqualTo(_ExistingBook.Name));
            });
            //Assert.That(actual, Is.Not.Null.And.Has.Property("Name").EqualTo("Necronomicon"));
        }
    }
    
    public class DaoDictionaryImplTests : DaoTestsBase<DaoDictionaryImpl<Book>>
    {
        protected override DaoDictionaryImpl<Book> CreateAndInitDao()
        {
           var repo = new Dictionary<string, Book> { { "existingKey", _ExistingBook } };
           return new DaoDictionaryImpl<Book>(repo);
        }
    }
    
    [Category("Integration")]
    public class DaoFileImplTests : DaoTestsBase<DaoFileImpl<Book>>
    {
        private DirectoryInfo? dirInfo;
        private string? tmpFolder;

        protected override DaoFileImpl<Book> CreateAndInitDao()
        {
            dirInfo = Directory.CreateTempSubdirectory("tdd-DaoFileImplTests");
            tmpFolder = dirInfo.FullName;
            
            var dao = new DaoFileImpl<Book>(tmpFolder);
            dao.Save(_ExistingBook, "existingKey");
            
            return dao;
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
        public void itShouldFailForGetIfIOError()
        {
            var filePath = Path.Combine(tmpFolder!, "existingKey.json");
            File.WriteAllText(filePath, "this_is_broken_json");
            DaoException error = Assert.Throws<DaoException>(() => _dao.Get("existingKey"));
            Assert.That(error.Message, Is.EqualTo("DaoFileImpl.get failed"));
        }
        
        [Test]
        public void itShouldFailForSaveIfIOError()
        {
            var book = new Book();
            book.Name = "Hitchhiker's Guide to the Galaxy";
            
            Directory.Delete(tmpFolder!, true);
            
            DaoException error = Assert.Throws<DaoException>(() => _dao.Save(book, "someKey"));
            Assert.That(error.Message, Is.EqualTo("DaoFileImpl.Save failed"));
        }
    }
}