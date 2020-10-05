using System;
using System.Collections.Generic;
using static System.Console;

namespace Libraries
{
    public partial class Person
    {
        /*
        Fields
            Constant
            Read-only
            Event
        */
        public string Name;
        public DateTime DateOfBirth;
        public PlacesToVisit Places;
        public List<Person> Children = new List<Person>();

        public const string Species = "Homo Sapiens";
        public readonly string HomePlanet = "Earth";
        public readonly DateTime Instantiated;
        public DefaultThings defaultOccurrence;
        /*
        Methods
            Constructor
            Property
            Indexer
            Operator
        */
        public Person()
        {
            Name = "Unknown";
            Instantiated = DateTime.Now;
        }

        public Person(string initialName , string homePlanet)
        {
            Name = initialName;
            HomePlanet = homePlanet;
            Instantiated = DateTime.Now;
        }
        /*
        private
        internal
        protected
        public
        internal protected
        private protected
        */


        // Methods
        public void WriteConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}");
        }

        public string GetOrigin()
        {
            return $"{Name} was \n born on {HomePlanet}.";
        }

        public (string Name, int Number) GetFruit()
        {
            return (Name : "Apples", Number : 5);
        }

        public void PasssingParameters (int x, ref int y, out int z)
        {
            // out parameters CANNOT have default
            // AND must be initialized inside method
            z = 99;
            x++;
            y++;
            z++;
        }
    }
}
