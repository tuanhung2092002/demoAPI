using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;



namespace Serialize_Deserialize
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person {
                    Name = "Name1", Age = 20, Phone = "Phone1", Address = "Address1"},
                new Person {
                    Name = "Name2", Age = 20, Phone = "Phone2", Address = "Address2"},
                new Person {
                    Name = "Name3", Age = 20, Phone = "Phone3", Address = "Address3"},
                new Person {
                    Name = "Name4", Age = 20, Phone = "Phone4", Address = "Address4"},
                new Person {
                    Name = "Name5", Age = 20, Phone = "Phone5", Address = "Address5"}
            };

            JSON(people);

            XML(people);

            Console.ReadKey();

        }
        private static void JSON(List<Person> people)
        {

            // Serialize đối tượng thành JSON
            string json = JsonConvert.SerializeObject(people);
            Console.WriteLine("Serialized JSON:");
            Console.WriteLine(json);

            Console.WriteLine("----------------------------------------------------------------");


            // Deserialize JSON thành đối tượng
            List<Person> deserializedPeople = JsonConvert.DeserializeObject<List<Person>>(json);
            Console.WriteLine("\nDeserialized People:");
            foreach (var write in deserializedPeople)
            {
                Console.WriteLine();
                Console.WriteLine("Name: " + write.Name);
                Console.WriteLine("Age: " + write.Age);
                Console.WriteLine("Phone: " + write.Phone);
                Console.WriteLine("Address: " + write.Address);
            }    
                

        }
        private static void XML(List<Person> people)
        {

            // Serialize danh sách thành XML

            XmlSerializer xml = new XmlSerializer(typeof(List<Person>));
            using (StringWriter writer = new StringWriter())
            {
                xml.Serialize(writer, people);
                string xmlString = writer.ToString();

                // In nội dung XML ra màn hình
                Console.WriteLine("Serialized XML:");
                Console.WriteLine(xmlString);
                Console.WriteLine("----------------------------------------------------------------");


                // Deserialize XML thành danh sách đối tượng Person
                List<Person> list_people;
                using (StringReader stringReader = new StringReader(xmlString))
                {
                    list_people = (List<Person>)xml.Deserialize(stringReader);
                }

                // In danh sách đối tượng Person
                Console.WriteLine("\nDeserialized People:");
                foreach (var write in list_people)
                {
                    Console.WriteLine();
                    Console.WriteLine("Name: " + write.Name);
                    Console.WriteLine("Age: " + write.Age);
                    Console.WriteLine("Phone: " + write.Phone);
                    Console.WriteLine("Address: " + write.Address);
                }
            }
        }
    }
}
