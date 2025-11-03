using NUnit.Framework;
using TDD.Matchers;
using System.Text.RegularExpressions;

namespace TDD.Tests.Matchers
{
    public class StringsTest
    {
        [Test]
        public void MyEmailIsString()
        {
            Assert.That(Strings.MyEmail, Is.TypeOf<string>(), "MyEmail should be of type string");
        }

        [Test]
        public void MyEmailStartsWithAndreas()
        {
            Assert.That(Strings.MyEmail, Does.StartWith("andreas"), "MyEmail should start with 'andreas'");
        }

        [Test]
        public void MyEmailEndsWithDotEu()
        {
            Assert.That(Strings.MyEmail, Does.EndWith(".eu"), "MyEmail should end with '.eu'");
        }

        [Test]
        public void MyEmailDoesNotEndWithDotCom()
        {
            Assert.That(Strings.MyEmail, Does.Not.EndWith(".com"), "MyEmail should not end with '.com'");
        }

        [Test]
        public void MyEmailIncludesBinary()
        {
            Assert.That(Strings.MyEmail, Does.Contain("binary"), "MyEmail should contain 'binary'");
        }

        [Test]
        public void MyEmailIncludesAndreasAndStars()
        {
            Assert.That(Strings.MyEmail, Does.Contain("andreas").And.Contain("stars"), "MyEmail should contain both 'andreas' and 'stars'");    

            Assert.Multiple(() =>
            {
                Assert.That(Strings.MyEmail, Does.Contain("andreas"), "MyEmail should contain 'andreas'");
                Assert.That(Strings.MyEmail, Does.Contain("stars"), "MyEmail should contain 'stars'");
            });
        }

        [Test]
        [Description("Should verify that MyEmail matches a basic email regex pattern")]
        public void MyEmailMatchesRegex()
        {
            String pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Assert.That(
                Strings.MyEmail, Does.Match(pattern),
                "MyEmail should match the email regex pattern");  
        }
    }
}
