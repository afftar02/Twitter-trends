using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter_trends.Models;

namespace Twitter_trends.Data
{
    public class DataBase
    {

        private static string[] TWEET_FILE_NAMES = { 
            "cali_tweets2014.txt",
            "family_tweets2014.txt",
            "football_tweets2014.txt",
            "high_school_tweets2014.txt",
            "movie_tweets2014.txt",
            "shopping_tweets2014.txt",
            "snow_tweets2014.txt",
            "texas_tweets2014.txt",
            "weekend_tweets2014.txt"
        };

        private List<Tweet> tweets;

        private Dictionary<State, double> statesHappiness;

        public DataBase()
		{
            this.tweets = new List<Tweet>();
            this.statesHappiness = new Dictionary<State, double>();
		}

        public void addTweet(Tweet tweet)
		{
            this.tweets.Add(tweet);
		}

        public int length()
		{
            return tweets.Count();
		}

        public double getStateHappiness(State state)
		{
            double happiness;
            if(!statesHappiness.TryGetValue(state, out happiness))
			{
                throw new TwitterTrendsException("Coudn't find state" + state.Name + " in states.");
			}
            return happiness;
		}

        
    }
}
