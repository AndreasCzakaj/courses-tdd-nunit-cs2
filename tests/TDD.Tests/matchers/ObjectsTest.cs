using NUnit.Framework;
using System.Collections.Generic;
using TDD.Matchers;

namespace TDD.Tests.Matchers
{
    public class ObjectsTest
    {
        private List<Person> people;
        private Person person;
        
        [SetUp]
        public void Setup()
        {
            people = PeopleProvider.GetPeople();
            person = people[23];
        }

        [Test]
        [Description("Should verify that the people list is initialized and has 1000 entries")]
        public void Init_ShouldHaveCorrectSize()
        {
            Assert.That(people, Has.Count.EqualTo(1000), "People list should have 1000 entries");
        }

        [Test]
        public void VerifyPersonEqualsPerson()
        {
            var expectedPerson = new Person
            {
                Id = 24,
                FirstName = "Kim",
                LastName = "Rawcliffe",
                Email = "krawcliffen@seesaa.net",
                IpAddress = "55.247.214.105",
            };

            // Compare objects by properties (NUnit 4.4+)
            Assert.That(person, Is.EqualTo(expectedPerson).UsingPropertiesComparer());

            // Compare objects by properties (NUnit 4.4+)
            Assert.That(person, Is.EqualTo(expectedPerson).UsingPropertiesComparer());

            // Verify they are not the same object reference
            Assert.That(person, Is.Not.SameAs(expectedPerson));
        }

        [Test]
        [Ignore("TODO: Should verify that person has FirstName 'Kim'")]
        public void VerifyPersonHasFirstNameKim()
        {
        }

        [Test]
        [Ignore("TODO: Should verify that person has fields 'FirstName' and 'Email'")]
        public void VerifyPersonContainsFields()
        {
        }

        [Test]
        [Ignore("TODO: Should verify that person contains values LastName: 'Rawcliffe' and Email: 'krawcliffen@seesaa.net'")]
        public void VerifyPersonContainsValues()
        {
        }
    }
}
