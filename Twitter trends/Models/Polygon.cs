using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_trends.Models
{
    public class Polygon
    {
        private List<Point> points = new List<Point>();

        public List<Point> Points { get => points; set => points = value; }

        public Polygon()
        {

        }

        public Polygon(List<Point> points)
        {
            Points = points;
        }

        public static bool IsInside(Polygon polygon, Location location)
        {
            bool flag = false;
            for (int i = 0, j = polygon.Points.Count - 1; i < polygon.Points.Count; j = i++)
            {
                if ((((polygon.Points[i].Y <= location.longtitude) && (location.longtitude < polygon.Points[j].Y)) || ((polygon.Points[j].Y <= location.longtitude)
                    && (location.longtitude < polygon.Points[i].Y))) &&
                    (((polygon.Points[j].Y - polygon.Points[i].Y) != 0) &&
                    (location.latitude > ((polygon.Points[j].X - polygon.Points[i].X)
                    * (location.longtitude - polygon.Points[i].Y) / (polygon.Points[j].Y - polygon.Points[i].Y) + polygon.Points[i].X))))
                {
                    flag = !flag;
                }
            }
            return flag;
        }
    }
}
