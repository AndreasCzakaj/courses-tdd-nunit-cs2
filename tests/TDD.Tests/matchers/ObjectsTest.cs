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
        [Ignore("TODO: Should verify that the people list is initialized and has 1000 entries")]
        public void Init_ShouldHaveCorrectSize()
        {
        }

        [Test]
        [Ignore("TODO: Should verify that person has FirstName 'Kim'")]
        public void VerifyPersonAtIndex23HasFirstNameKim()
        {
        }

        [Test]
        [Ignore("TODO: Should verify that person has fields 'Id' and 'IpAddress'")]
        public void VerifyPersonAtIndex23ContainsFields()
        {
        }

        [Test]
        [Ignore("TODO: Should verify that person contains specific values")]
        public void VerifyPersonAtIndex23ContainsValues()
        {
        }
    }
}
