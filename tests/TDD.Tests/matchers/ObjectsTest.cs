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
        [Ignore("TODO: Should verify that person is equal to another (not same) person with the same values")]
        public void VerifyPersonEqualsPerson()
        {
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
