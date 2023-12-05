using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person ivan = new Person() { FirstName = "Ivan", LastName = "Shevelyn", Age = 20, Weight = 62};
            Console.WriteLine(ivan);

            Person? returned = SerializationAndDeserializationCycle(ivan);
            Console.WriteLine(returned);
        }

        static Person? SerializationAndDeserializationCycle(Person person)
        {
            string jsonPerson = JsonConvert.SerializeObject(person);
            Console.WriteLine($"JSON person:\n{jsonPerson}");

            IFormatter formatter = new BinaryFormatter();
            byte[] serializedData;
            string deserializedData;

            using (var memoryStream = new MemoryStream())
            {
                formatter.Serialize(memoryStream, jsonPerson);
                serializedData = memoryStream.ToArray();
            }

            try
            {
                using (var memoryStream = new MemoryStream(serializedData))
                {
                    deserializedData = (string)formatter.Deserialize(memoryStream);
                    Console.WriteLine($"Deserialized binary to json person:\n{deserializedData}");
                }

                Person? deserializedPerson = JsonConvert.DeserializeObject<Person>(deserializedData);

                return deserializedPerson;
            }
            catch 
            {
                return null;
            }
        }
    }
}