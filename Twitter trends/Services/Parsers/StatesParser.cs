using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Twitter_trends.Services.Parsers
{
    public static class StatesParser
    {
        public static void Parse(string path)
        {
            string jsonString = File.ReadAllText(path);
            jsonString = Regex.Replace(jsonString, @"[^\S\r\n]?[\[\]\:]?", "").Replace("{", "").Replace("}", "").Replace(",", " ");
            jsonString = Regex.Replace(jsonString, @"[\r\n]+", "\n").Replace("\"", "").Trim();

            string state_name = jsonString.Split('\n')[0];
            string state_info = "";
            jsonString = jsonString.Remove(0, 3);

           
            //Console.WriteLine(jsonString);
        }
    }
}
