using Newtonsoft.Json;

namespace Serialization
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        [JsonIgnore]
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"Name: {FirstName}; Last name: {LastName}; Age: {Age}; Weight: {Weight}";
        }
    }
}
