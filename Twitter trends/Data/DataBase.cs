using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twitter_trends.Models;

namespace Twitter_trends.Data
{
    class DataBase
    {
        private static DataBase Instance = null;

        private List<Tweet> tweets;
        private Dictionary<char, List<Sentiment>> sentiments;
        private Country country;
        public string Path { private get; set; }

        public List<Tweet> Tweets
        {
            get
            {
                if (tweets != null)
                {
                    return tweets;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }
        public Dictionary<char, List<Sentiment>> Sentiments { get { return sentiments; } }

        public Country Country { get { return country; } }

        private DataBase()
        {
            sentiments = new Dictionary<char, List<Sentiment>>();//SentimentParser.Parse(@"..\..\..\Data\Sentiments\sentiments.csv");
        }

        public static DataBase GetInstance()
        {
            if (Instance == null)
            {
                Instance = new DataBase();
            }
            return Instance;
        }
        public void SetPathTweetFile(string path)
        {
            GetInstance().Path = path;
        }
        public async Task StartNewState()
        {
            tweets = new List<Tweet>();//TweetParser.Parse(Path);
            country = new Country(new List<State>());//ExtraFuncs.GroupTweetsByStates(tweets, @"..\..\..\Data\States\states.json");
        }

    }
}
