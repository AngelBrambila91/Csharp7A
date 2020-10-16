namespace Libraries
{
    public partial class Person
    {
        public string Origin => $"{Name} was born on {HomePlanet}";
        public string Greeting => $"{Name} says Hello"; // Lambda expression
        public int Age => System.DateTime.Today.Year - DateOfBirth.Year;

        public string FavoriteIceCream {get; set;} // settable
        private string favoriteColor;
        public string FavoriteColor { 
        get => favoriteColor;
        set
        {
            switch (value.ToLower())
            {
                case "red":
                case "green":
                case "blue":
                favoriteColor = value;
                break;
                default:
                throw new System.ArgumentException(
                    $"{value} is not a primary color." +
                    "Choose from : red, green, blue");
            }
        }
        }

        private string secondName;
        public string getSecondName()
        {
            return secondName;
        }
        public void setSecondName (string value)
        {
            secondName = value;
        }
        
        private int myVar;
        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }
        
    }
}