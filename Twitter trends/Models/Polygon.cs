using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_trends.Models
{
    class Polygon
    {
        List<Point> points = new List<Point>();

        public List<Point> Points { get => points; set => points = value; }

        public Polygon() { }

        public Polygon(Polygon polygon)
        {
            points = new List<Point>(polygon.Points);
        }
    }
}
