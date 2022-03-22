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

        List<Polygon> polygons = new List<Polygon>();

        internal List<Polygon> Polygons { get => polygons; set => polygons = value; }
        private List<Tweet> tweets = new List<Tweet>();
        public List<Tweet> Tweets { get => tweets; set => tweets = value; }
        private double totalWeight;
        public double TotalWeight { get => totalWeight; set => totalWeight = value; }
        public bool isMoodDefined = false;
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
