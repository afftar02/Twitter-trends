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

		private static readonly char SPLITTER = '_';

		private static readonly string COMMA = ",";

		private static readonly int DATE_TIME_LENGTH = 19;

		private static readonly char START_OF_LINE = '[';

		private static readonly string SPACE = " ";

		private static readonly string REGEX_MULTIPLE_SPACES = @"\s+";

		private static readonly string REGEX_LINK_FIND = @"http[^\s]+";

		private static readonly string REGEX_PUNCTUATION_FIND = @"[\,\.\-\!]";

		private static Location LocationParser(string line)
		{
			line = line.Substring(1, line.Length - 3);
			string[] location = line.Split(COMMA.ToCharArray()[0]);
			return new Location(double.Parse(location[0], CultureInfo.InvariantCulture),
				double.Parse(location[1].Substring(1,location[1].Length-1), CultureInfo.InvariantCulture));
		}

		private static void DeleteSpaces(ref List<string> messageList)
        {
            for (int i = 0; i < messageList.Count; i++)
            {
                if (messageList[i] == string.Empty)
                {
					messageList.RemoveAt(i);
                }
            }
        }

		private static List<string> MessageParser(string message)
		{
			List<string> splittedMessage = new List<string>(message.Split(SPACE.ToCharArray()[0]));
			DeleteSpaces(ref splittedMessage);
			return splittedMessage;
		}

		public static Tweet Parse(string line)
		{
			if (line[0] != START_OF_LINE)
			{
				throw new TwitterTrendsException("Invalid data for tweets");
			}
			string[] splittedLine = line.Split(SPLITTER);
			string date = splittedLine[1].Substring(1, DATE_TIME_LENGTH);
			string message = splittedLine[1].Substring(20, splittedLine[1].Length-DATE_TIME_LENGTH-1);
			message = Regex.Replace(message, REGEX_LINK_FIND, COMMA);
			message = Regex.Replace(message, REGEX_PUNCTUATION_FIND, (m) => SPACE + m + SPACE);
			message = Regex.Replace(message, REGEX_MULTIPLE_SPACES, SPACE);
			message = message.Trim();
			Console.WriteLine(date);
			Console.WriteLine(message);
			List<string> testParsedList = MessageParser(message);
			return new Tweet(LocationParser(splittedLine[0]), DateTime.Parse(date), MessageParser(message));
		}
	}
}
