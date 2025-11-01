namespace TDD
{
    public static class Hello
    {
        public static string GetHello()
        {
            return "friends";
        }

        public static int Answer(string question)
        {
            return 43;
        }

        public static List<string> GetList()
        {
            return new List<string>
            {
                "a",
                "b",
                "c"
            };
        }

        public static (string FirstName, string LastName) GetObject()
        {
            return ("Joey", "Ramone");
        }
    }
}
