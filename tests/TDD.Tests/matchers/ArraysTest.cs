using NUnit.Framework;
using System.Collections.Generic;
using TDD.Matchers;

namespace TDD.Tests.Matchers
{
    public class ArraysTests
    {

        [Test]
        [Ignore("TODO: List should have size 3")]
        public void ListShouldHaveSize3()
        {
            AssertThat(Arrays.GetList(), Has.Count.EqualTo(3), "List should have size 3");
        }

        [Test]
        [Ignore("TODO")]
        public void ListShouldContain_a()
        {
        }

        [Test]
        [Ignore("TODO")]
        public void ListShouldNotContain_d()
        {
        }

        [Test]
        [Ignore("TODO")]
        public void ListShouldContain_c_and_a()
        {
        }

        [Test]
        [Ignore("TODO")]
        public void ListShouldHaveNoDuplicates()
        {
        }
    }
}
