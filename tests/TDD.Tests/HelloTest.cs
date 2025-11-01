using NUnit.Framework;
using TDD;

namespace TDD.Tests
{
    public class HelloTest
    {
        [Test]
        public void GetValue_ShouldReturnAnswer()
        {
            // Arrange
            var input = "What's the meaning of it all?";

            // Act
            var actual = Hello.Answer(input);

            // Assert
            const int expected = 42;
            Assert.That(actual, Is.EqualTo(expected), "Answer should be 42... and welcome to the course");
            Assert.That(actual, Is.Not.EqualTo(666), "Answer should not be the devil's number");
        }
    }
}
