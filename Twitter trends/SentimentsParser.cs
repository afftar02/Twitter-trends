using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_trends
{
    class SentimentsParser
    {
        private static char COMMA=',';

        private static Sentiments SentimentParser(string line)
        {
            string[] parts = line.Split(COMMA);
            return new Sentiments(parts[0], double.Parse(parts[1], System.Globalization.NumberStyles.AllowLeadingSign |
                                                                  System.Globalization.NumberStyles.AllowParentheses |
                                                                  System.Globalization.NumberStyles.AllowLeadingWhite |
                                                                  System.Globalization.NumberStyles.AllowThousands |
                                                                  System.Globalization.NumberStyles.AllowDecimalPoint |
                                                                  System.Globalization.NumberStyles.AllowTrailingWhite));
        }
    }
}
