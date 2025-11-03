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
        [Description("Should verify that person has FirstName 'Kim'")]
        public void VerifyPersonHasFirstNameKim()
        {
            Assert.That(person.FirstName, Is.EqualTo("Kim"));
        }

        [Test]
        public void VerifyPersonContainsFields()
        {
            Assert.Multiple(() =>
            {
                Assert.That(person, Has.Property("FirstName").And.Property("Email"));
            });
        }

        [Test]
        [Description("Should verify that person is equal to expected person but not same")]
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

            Assert.That(person, Is.EqualTo(expectedPerson).UsingPropertiesComparer());

            Assert.That(person, Is.Not.SameAs(expectedPerson));
        }

        [Test]
        [Description("Should verify that person is almost equal to expected person exept for Id")]
        public void VerifyPersonEqualsPersonExceptId()
        {
            var expectedPerson = new Person
            {
                Id = 340643069,
                FirstName = "Kim",
                LastName = "Rawcliffe",
                Email = "krawcliffen@seesaa.net",
                IpAddress = "55.247.214.105",
            };

            Assert.That(person, Is.EqualTo(expectedPerson).UsingPropertiesComparer(
                o => o.Excluding(nameof(Person.Id))
            ));
        }

        [Test]
        [Description("Should verify that person contains values LastName: 'Rawcliffe' and Email: 'krawcliffen@seesaa.net'")]
        public void VerifyPersonContainsValues()
        {
            var expectedPerson = new Person
            {
                LastName = "Rawcliffe",
                Email = "krawcliffen@seesaa.net",
            };
            
            // variant a
            Assert.That(person, Is.EqualTo(expectedPerson).UsingPropertiesComparer(
                o => o.Using(nameof(Person.LastName), nameof(Person.Email)
            )));
            
            // variant b
            Assert.That(
                person, 
                Has.Property("LastName").EqualTo("Rawcliffe").
                And.Property("Email").EqualTo("krawcliffen@seesaa.net")
            );
        }
    }
}
