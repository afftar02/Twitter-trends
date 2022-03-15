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
           
            Console.WriteLine(jsonString);
        }
    }
}
