using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter_trends.Models;
using Twitter_trends.Services.Parsers;
using Twitter_trends.Services.Readers;

namespace Twitter_trends.Data
{
    public class DataBase
    {

        private static string[] TWEET_FILE_NAMES = {
            @"..\..\Data\Resources\states\cali_tweets2014.txt",
            @"..\..\Data\Resources\states\family_tweets2014.txt",
            @"..\..\Data\Resources\states\football_tweets2014.txt",
            @"..\..\Data\Resources\states\high_school_tweets2014.txt",
            @"..\..\Data\Resources\states\movie_tweets2014.txt",
            @"..\..\Data\Resources\states\shopping_tweets2014.txt",
            @"..\..\Data\Resources\states\snow_tweets2014.txt",
            @"..\..\Data\Resources\states\texas_tweets2014.txt",
            @"..\..\Data\Resources\states\weekend_tweets2014.txt"
        };

        public List<Tweet> tweets { get; private set; }

        private Dictionary<State, double?> statesHappiness;

        public static List<State> states = StatesParser.Parse(StatesReader.Read(@"..\..\Data\Resources\states\states.json"));

        private static readonly char END_OF_LINE = '\n';

        public Country country { get; private set; }

        public string Path { get; set; }


        private void FillTweetsList(string filePath)
		{
            this.tweets = new List<Tweet>();
            string []lines = TxtReader.Read(filePath).Split(END_OF_LINE);
            foreach (string line in lines)
            {
                tweets.Add(TweetParser.Parse(line));
			}

        }

        private void FillStatesHappiness()
		{
            this.statesHappiness = new Dictionary<State, double?>();
            for(int i = 0; i < states.Count; i++)
			{
                double? happiness = 0.0;
                bool flag = false;
                int numberOfTweetsInState = 0;
                for(int j = 0; j < tweets.Count; j++)
				{
                    if(tweets[j].locationState == states[i].Name)
					{
                        happiness += tweets[j].happiness;
                        numberOfTweetsInState++;
                        flag = true;
					}
				}
				if (flag)
				{
                    statesHappiness.Add(states[i], happiness / numberOfTweetsInState);
				}
				else
				{
                    statesHappiness.Add(states[i], null);
				}
                Console.WriteLine(states[i].Name + ' ' + statesHappiness[states[i]].ToString());
			}
            
        }
        public async Task StartDatabase()
		{
            FillTweetsList(Path);
            FillStatesHappiness();
            country = new Country(states);
		}

        public void addTweet(Tweet tweet)
		{
            this.tweets.Add(tweet);
		}

        public int length()
		{
            return tweets.Count();
		}

        public double? getStateHappiness(State state)
		{
            double? happiness;
            if(!statesHappiness.TryGetValue(state, out happiness))
			{
                throw new TwitterTrendsException("Couldn't find state" + state.Name + " in states.");
			}
            state.isMoodDefined = true;
            return happiness;
		}

        
    }
}
