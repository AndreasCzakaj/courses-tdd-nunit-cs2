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
        [Ignore("TODO")]
        public void VerifyPersonHasFirstNameKim()
        {
        }

        [Test]
        [Description("Should verify that person has fields FirstName and Email")]
        [Ignore("TODO")]
        public void VerifyPersonContainsFields()
        {
        }

        [Test]
        [Description("Should verify that person is equal to expected person but not same")]
        [Ignore("TODO")]
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
        }

        [Test]
        [Description("Should verify that person is almost equal to expected person exept for Id")]
        [Ignore("TODO")]
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
        }

        [Test]
        [Description("Should verify that person contains values LastName: 'Rawcliffe' and Email: 'krawcliffen@seesaa.net'")]
        [Ignore("TODO")]
        public void VerifyPersonContainsValues()
        {
            var expectedPerson = new Person
            {
                LastName = "Rawcliffe",
                Email = "krawcliffen@seesaa.net",
            };
        }
    }
}
