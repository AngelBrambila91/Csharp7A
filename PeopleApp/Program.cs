using System;
using Libraries;
using static System.Console;
namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount.InterestRate = 0.01M;
            var luisAccount = new BankAccount();
            luisAccount.AccountName = "Sr. Luis";
            luisAccount.Balance = 3200;
            #region Create Person Using fields    
            var luis = new Person();
            luis.Name = "Luis Chavez";
            luis.DateOfBirth = new DateTime(2001, 12, 22);
            luis.Places = PlacesToVisit.Spain;
            luis.Children.Add(new Person {Name = "Santiago"});
            luis.Children.Add(new Person {Name = "Zoe"});
            WriteLine($"{luis.Name} was born on {luis.HomePlanet}");
            #endregion

            #region Print kids of person
                
            WriteLine($"{luis.Name} has {luis.Children.Count} children");

            for (int child = 0; child < luis.Children.Count; child++)
            {
                WriteLine($"{luis.Children[child].Name}");
            }

            WriteLine($"Luis was born on {luis.DateOfBirth:dddd, MMMM d yyyy} and his favorite place is {luis.Places}");
            #endregion

            #region Create person with default constructor    
            var brunito = new Person
            {
                Name = "Suavecito",
                DateOfBirth = new DateTime(2003, 1, 15) 
            };
            WriteLine($"Brunito was born on {brunito.DateOfBirth:dddd, MMMM d yyyy}");
            #endregion

            #region Create Unkown user with constructor
                var blankPerson = new Person();
                WriteLine($"{blankPerson.Name} was created at {blankPerson.Instantiated:hh:mm:ss} on a {blankPerson.Instantiated:dddd}.");
            #endregion

            #region Using Overload Constructor with parameters
            var torres = new Person("Torres", "Jupiter");
            WriteLine($"{torres.Name} was created at {torres.Instantiated:hh:mm:ss} on a {torres.Instantiated:dddd} and comes from {torres.HomePlanet}");
            #endregion

            #region Default Class    
            var defaultThings = new DefaultThings();
            WriteLine($"{defaultThings.Population} , {defaultThings.When}, {defaultThings.Name}, {defaultThings.People}");

            if(luis.Name != null)
            {
                //luis.defaultOccurrence.Name = luis.Name;
            }
            #endregion

            #region Using Methods
                luis.WriteConsole();
                WriteLine(luis.GetOrigin());

                var fruit = luis.GetFruit();
                WriteLine($"{fruit.Name}, {fruit.Number} luis eats.");
            #endregion

            #region Ref and Out
                int a = 10;
                int b = 20;
                int c = 30;

                WriteLine($"Before : a = {a}, b = {b}, c = {c} ");
                brunito.PasssingParameters(a, ref b, out c);
                WriteLine($"After : a = {a}, b = {b}, c = {c} ");
            #endregion

            var sam = new Person
            {
                Name = "Sammy",
                DateOfBirth = new DateTime(2000, 3, 15)
            };
            WriteLine(sam.Origin);
            WriteLine(sam.Greeting);
            WriteLine(sam.Age);

            #region Using properties
                sam.FavoriteIceCream = "Chocolate";
                WriteLine($"Sam's favorite IceCream is {sam.FavoriteIceCream}");
                sam.FavoriteColor = "Red";
                WriteLine($"Sam's favorite Color is {sam.FavoriteColor}");
            #endregion
        }
    }
}
