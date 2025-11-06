using System;

namespace TDD.Uss
{
    public class ValidationException : Exception
    {
        public ValidationException(Dictionary<string, string> fields) : base(Newtonsoft.Json.JsonConvert.SerializeObject(fields))
        {
            this.Fields = fields;
        }

        public Dictionary<string, string> Fields { get; }
    }
}
