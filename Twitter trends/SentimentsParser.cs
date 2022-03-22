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

        public static Sentiments Parse(string line)
        {
            string[] sentiments=line.Split('\n');
            foreach (var sentiment in sentiments)
            {
                string[] parts = sentiment.Split(COMMA);

                return null;
            }
            return null;
        }
    }
}
