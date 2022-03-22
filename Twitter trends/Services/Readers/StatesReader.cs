using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Twitter_trends.Services.Readers
{
    class StatesReader
    {
        public static string Read(string filePath)
        {
			try
			{
				string jsonString = File.ReadAllText(filePath);
				return jsonString;
			}
			catch (Exception e)
			{
				throw new TwitterTrendsException("Couldn't read from file: " + filePath);
			}
		}
    }
}
