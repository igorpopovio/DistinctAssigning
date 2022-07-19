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

            var distinctFirstNames = people.Select(person => person.FirstName).Distinct();
            if (distinctFirstNames.Count() == 1)
            {
                someone.FirstName = distinctFirstNames.Single();
            }

            var distinctLastNames = people.Select(person => person.LastName).Distinct();
            if (distinctLastNames.Count() == 1)
            {
                someone.LastName = distinctLastNames.Single();
            }

            var distinctAges = people.Select(person => person.Age).Distinct();
            if (distinctAges.Count() == 1)
            {
                someone.Age = distinctAges.Single();
            }

            Assert.That(someone.FirstName, Is.EqualTo("John"));
            Assert.That(someone.LastName, Is.EqualTo(null));
            Assert.That(someone.Age, Is.EqualTo(32));
        }
    }
}
