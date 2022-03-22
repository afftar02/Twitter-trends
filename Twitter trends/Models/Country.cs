using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_trends.Models
{
    class Country
    {
        private string name;
        public string Name { get => name; set => name = value; }

        List<State> states = new List<State>();
        internal List<State> States { get => states; set => states = value; }

        public Country(List<State> states)
        {
            States = states;
            Name = "USA";
        }
    }
}
