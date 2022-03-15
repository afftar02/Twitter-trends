using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using Twitter_trends.Models;

namespace Twitter_trends.Services.Parsers
{
    public static class StatesParser
    {
        public static List<State> Parse(string jsonString)
        {
            jsonString = Regex.Replace(jsonString, @"[^\S\r\n]?[\[\]\:]?", "").Replace("{", "").Replace("}", "").Replace(",", " ");
            jsonString = Regex.Replace(jsonString, @"[\r\n]+", "\n").Replace("\"", "").Trim();

            List<State> states = new List<State>();
            List<Polygon> polygons = new List<Polygon>();
            List<Point> points = new List<Point>();
            string stateName = String.Empty;
            string[] splittedInfo = jsonString.Split('\n');
            foreach (var line in splittedInfo)
            {
                if(line!=" ")
                {
                    if (line.Any(char.IsLetter))
                    {
                        if (stateName == String.Empty)
                        { 
                            stateName = line; 
                        }
                        else
                        {
                            states.Add(new State(stateName,new List<Polygon>(polygons)));
                            polygons.Clear();
                            stateName = line;
                        }
                    }
                    else if(line.Any(char.IsDigit))
                    {
                        double x= Convert.ToDouble(line.Replace(".", ",").Split(' ')[1]);
                        double y = Convert.ToDouble(line.Replace(".", ",").Split(' ')[0]);
                        points.Add(new Point(x, y));
                    }
                }
                else
                {
                    polygons.Add(new Polygon(new List<Point>(points)));
                    points.Clear();
                }
            }
            return states;
        }
    }
}
