using System;
using System.Collections.Generic;

namespace Libraries
{
    public class DefaultThings
    {
        public int Population;
        public DateTime When;
        public string Name;
        public List<Person> People;

        public DefaultThings()
        {
            Population = default;
            When = default;
            Name = default;
            People = default;
        }
        public DefaultThings(string Name)
        {
            
        }
    }
}