using NUnit.Framework;
using TDD.Uss;

namespace TDD.Tests.Uss
{
    public class LoginTests
    {
        private DirectoryInfo? dirInfo;
        private string? tmpFolder;
       /* private Dao<User> dao;
        private string existingUserEmail = "existing-user@bla.com";
        private string existingUserPassword = "existingUserPassword";*/
        private UserSelfService service;

        [SetUp]
        public void SetUp()
        {
            dirInfo = Directory.CreateTempSubdirectory("tdd-LoginTests");
            tmpFolder = dirInfo.FullName;

            /*dao = new DaoDictionaryImpl<User>(new Dictionary<string, User>(){
                {
                    existingUserEmail,
                    new User {
                        Email = existingUserEmail,
                        PasswordHash = existingUserPassword,
                    }
                }
            });*/
            service = new UserSelfService();
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
        [Ignore("TODO")]
        public void ItShouldFailWhenEmailIsEmpty()
        {
        }

        [Test]
        [Ignore("TODO")]
        public void ItShouldFailWithLoginExceptionWhenUserEmailIsUnknown()
        {
        }

        [Test]
        [Ignore("TODO")]
        public void ItShouldFailWithUserExceptionWhenUserPasswordIsWrong()
        {
        }
    }
}
