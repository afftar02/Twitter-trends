using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Twitter_trends
{
	class TweetParser
	{

		private static char SPLITTER = '_';

		private static char COMMA = ',';

		private static int DATE_TIME_LENGTH = 19;

		private static char START_OF_LINE = '[';

		private static Location LocationParser(string line)
		{
			line = line.Substring(1, line.Length - 3);
			string[] location = line.Split(COMMA);
			return new Location(double.Parse(location[0], CultureInfo.InvariantCulture),
				double.Parse(location[1].Substring(1,location[1].Length-1), CultureInfo.InvariantCulture));
		}

		public static Tweet Parse(string line)
		{
			if (line[0] != START_OF_LINE)
			{
				throw new Exception("Fuck my life");
			}
			string[] splittedLine = line.Split(SPLITTER);
			string date = splittedLine[1].Substring(1, DATE_TIME_LENGTH);
			string message = splittedLine[1].Substring(20, splittedLine[1].Length-DATE_TIME_LENGTH-1);
			return new Tweet(LocationParser(splittedLine[0]), DateTime.Parse(date), message);
		}
	}
}
