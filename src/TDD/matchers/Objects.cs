using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TDD.Matchers
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;
    }

    public static class PeopleProvider
    {
        public static List<Person> GetPeople()
        {
            var baseDirectory = AppContext.BaseDirectory;
            var projectRoot = Path.Combine(baseDirectory, "../../../../../src/TDD/matchers");
            var jsonFilePath = Path.Combine(projectRoot, "ppl.json");
            var json = File.ReadAllText(jsonFilePath);
            return JsonSerializer.Deserialize<List<Person>>(json) ?? new List<Person>();
        }
    }
}
