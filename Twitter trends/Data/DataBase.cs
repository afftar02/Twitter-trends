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

        private List<State> states;

        public DataBase()
		{
            this.tweets = new List<Tweet>();
            this.states = new List<State>();
		}

        public void addTweet(Tweet tweet)
		{
            this.tweets.Add(tweet);
		}

        public int length()
		{
            return tweets.Count();
		}

        public Tweet getTweet(int index)
		{
            if(index<0 || index > tweets.Count())
			{
                throw new TwitterTrendsException("Invalid index for getting tweet in database:" + index);
			}
            return tweets.ElementAt(index);
		}

        public State GetStateByLocation(Location loc)
        {
            foreach (var state in states)
            {
                foreach (var pol in state.Polygons)
                {
                    if (Polygon.IsInside(pol, loc))
                    {
                        return state;
                    }
                }
            }
            return new State();
        }
    }
}
