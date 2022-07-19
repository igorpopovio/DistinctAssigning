using NUnit.Framework;

namespace DistinctAssigning
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    class Tests
    {
        [Test]
        public void AssigningDistinctProperties()
        {
            var people = new[]
            {
                new Person { FirstName = "John", LastName = "Doe", Age = 32, },
                new Person { FirstName = "John", LastName = "Snyder", Age = 32, },
            };

            var someone = new Person();

            someone.FirstName = people.SelectDistinctOrDefault(person => person.FirstName);
            someone.LastName = people.SelectDistinctOrDefault(person => person.LastName);
            someone.Age = people.SelectDistinctOrDefault(person => person.Age);

            Assert.That(someone.FirstName, Is.EqualTo("John"));
            Assert.That(someone.LastName, Is.EqualTo(null));
            Assert.That(someone.Age, Is.EqualTo(32));
        }
    }
}
