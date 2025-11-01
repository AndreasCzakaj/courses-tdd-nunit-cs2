using NUnit.Framework;
using TDD.Misc;

namespace TDD.Tests.Misc
{
    [TestFixture]
    public class PersonTest
    {
        [Test]
        public void Person()
        {
            var person = new Person();
            person.CoreFirstName = "Kim";
            person.CoreLastName = "Gordon";
            person.CoreState = "active";
            person.AddrStreetAndNo = "Penny Lane";
            person.AddrZipAndCity = "Beverly Bills, 90210";
            person.AddrState = "California";

            Assert.That(person.CoreFirstName, Is.EqualTo("Kim"));
            Assert.That(person.CoreLastName, Is.EqualTo("Gordon"));
            Assert.That(person.CoreState, Is.EqualTo("active"));
            Assert.That(person.AddrStreetAndNo, Is.EqualTo("Penny Lane"));
            Assert.That(person.AddrZipAndCity, Is.EqualTo("Beverly Bills, 90210"));
            Assert.That(person.AddrState, Is.EqualTo("California"));
        }
    }
}