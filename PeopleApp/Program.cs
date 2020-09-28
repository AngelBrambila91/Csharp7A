using System;
using Libraries;
using static System.Console;
namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var luis = new Person();
            luis.Name = "Luis Chavez";
            luis.DateOfBirth = new DateTime(2001, 12, 22);
            luis.Places = PlacesToVisit.Spain;
            luis.Children.Add(new Person {Name = "Santiago"});
            luis.Children.Add(new Person {Name = "Zoe"});

            WriteLine($"{luis.Name} has {luis.Children.Count} children");

            for (int child = 0; child < luis.Children.Count; child++)
            {
                WriteLine($"{luis.Children[child].Name}");
            }

            WriteLine($"Luis was born on {luis.DateOfBirth:dddd, MMMM d yyyy} and his favorite place is {luis.Places}");

            var brunito = new Person
            {
                Name = "Suavecito",
                DateOfBirth = new DateTime(2003, 1, 15) 
            };
            WriteLine($"Brunito was born on {brunito.DateOfBirth:dddd, MMMM d yyyy}");
        }
    }
}
