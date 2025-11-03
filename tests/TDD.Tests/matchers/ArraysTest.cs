using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Collections.Generic;
using TDD.Matchers;

namespace TDD.Tests.Matchers
{
    public class ArraysTests
    {

        [Test]
        public void ListShouldHaveSize3()
        {
            Assert.That(Arrays.GetList(), Has.Count.EqualTo(3), "List should have size 3");
            Assert.That(Arrays.GetList().Count, Is.EqualTo(3), "List should have size 3");
        }

        [Test]
        public void ListShouldContain_a()
        {
            Assert.That(Arrays.GetList(), Contains.Item("a"), "List should contain 'a'");
            Assert.That(Arrays.GetList(), Does.Contain("a"), "List should contain 'a'");
            Assert.That(Arrays.GetList(), Has.Member("a"), "List should contain 'a'");
        }

        [Test]
        public void ListShouldNotContain_d()
        {
            Assert.That(Arrays.GetList(), Does.Not.Contain("d"), "List should contain 'd'");
        }

        [Test]
        public void ListShouldContain_c_and_a()
        {
            Assert.That(Arrays.GetList(), 
                Does.Contain("a").And.Contain("c"), 
                "List should contain both 'a' and 'c'"
            );

            Assert.Multiple(() =>
            {
                Assert.That(Arrays.GetList(), Does.Contain("a"));
                Assert.That(Arrays.GetList(), Does.Contain("c"));
            });
        }

        [Test]
        public void ListShouldHaveNoDuplicates()
        {
            Assert.That(Arrays.GetList(), Is.Unique, "List should have no duplicates");
        }
    }
}
