using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_trends.Models
{
    public class State
    {
        private string name;
        private List<Polygon> polygons = new List<Polygon>();

        public List<Polygon> Polygons { get => polygons; set => polygons = value; }
        public string Name { get => name; set => name = value; }

        public State()
        {

        }

        public State(string name, List<Polygon> polygons)
        {
            Name = name;
            Polygons = polygons;
        }
    }
}
