using System;
using static System.Console;
using System.IO;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.Xml.Serialization;
using System.Xml;
using System.Linq;
using System.Collections.Generic;

namespace WorkingWithFiles
{
    public class Person 
    {
        public Person()
        {

        }
        ~Person ()
        {

        }
        public Person (decimal initialSalary)
        {
            Salary = initialSalary;
        }
        [XmlAttribute("FName")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public HashSet<Person> Children { get; set; }
        protected decimal Salary {get; set;}        
    }
    class Program
    {
        static string[] People = new string[]
        {
            "Santiago", "Luis", "Suavecito", "FlyingPig"
        };
        static void Main(string[] args)
        {
            #region WorkingWithDirs                
            var newFolder = Combine(GetFolderPath(SpecialFolder.Desktop), "TestingDir", "Stuff");
            CreateDirectory(newFolder);
            WriteLine($"Folder Exists? {Exists(newFolder)}");
            //Delete(newFolder);
            WriteLine($"Folder Exists? {Exists(newFolder)}");
            #endregion

            #region Working With Files
                // string textFile = Combine(newFolder, "Dummy.txt");
                // string backupFile = Combine(newFolder, "Dummy.bak");

                // StreamWriter textWriter = File.CreateText(textFile);
                // textWriter.WriteLine("HOlo canobo");
                // textWriter.Close();

                // File.Copy(sourceFileName: textFile, destFileName: backupFile);
                // ReadLine();
                // File.Delete(textFile);
                // WriteLine("Reading from BackUpFile");
                // StreamReader textReader = File.OpenText(backupFile);
                // WriteLine(textReader.ReadToEnd());
            #endregion

            #region Working with XML
                WorkWithXml();
            #endregion

            #region Serialize XML
                SerializeXml();
            #endregion

        }

        static void WorkWithXml()
        {
            string xmlFile = Combine(GetCurrentDirectory(), "streams.xml");
            FileStream xmlFileStream = File.Create(xmlFile);
            XmlWriter xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings{ Indent = true });

            xml.WriteStartDocument();
            xml.WriteStartElement("People");

            foreach (string item in People)
            {
                xml.WriteElementString("Name", item);
            }

            xml.WriteEndElement();
            xml.Close();
            xmlFileStream.Close();
        }

        static void SerializeXml()
        {
            var people = new List<Person>
            {
                new Person(300000M) {
                    FirstName = "Santiago",
                    DateOfBirth = new DateTime (2000, 01, 01)
                },
                new Person(300000M) {
                    FirstName = "Samy",
                    DateOfBirth = new DateTime (2000, 01, 01)
                },
                new Person(300000M) {
                    FirstName = "Luis",
                    DateOfBirth = new DateTime (2000, 01, 01)
                },
                new Person(300000M) {
                    FirstName = "Brunito",
                    DateOfBirth = new DateTime (2000, 01, 01)
                },
                new Person(300000M) {
                    FirstName = "Suavecito",
                    DateOfBirth = new DateTime (2000, 01, 01)
                },
                new Person(300000M) {
                    FirstName = "FlyingPig",
                    DateOfBirth = new DateTime (2000, 01, 01)
                }
            };

            var xs = new XmlSerializer(typeof(List<Person>));
            string path = Combine(GetCurrentDirectory(), "people.xml");
            using (FileStream stream = File.Create(path))
            {
                xs.Serialize(stream, people);
            } // stream.Close();

            using (FileStream xmlLoad = File.Open(path, FileMode.Open))
            {
                var loadPeople = (List<Person>)xs.Deserialize(xmlLoad);
                foreach (var item in loadPeople)
                {
                    WriteLine($"{item.FirstName} {item.Children.Count}");
                }
            }

            string pathJson = Combine(GetCurrentDirectory(), "people.json");
            using (StreamWriter jsonStream = File.CreateText(pathJson))
            {
                var jss = new Newtonsoft.Json.JsonSerializer();
                jss.Serialize(jsonStream, people);
            }

            WriteLine(File.ReadAllText(pathJson));
        }
    
    }
}
