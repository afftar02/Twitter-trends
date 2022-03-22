using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_trends.Data
{
    public class DataBase
    {

        private static string[] TWEET_FILE_NAMES = { "cali_tweets2014.txt",
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
        private List<TweetParams> tweetsParams;
        private Sentiments sentiments;
        public DataBase()
		{
            this.tweets = new List<Tweet>();
            this.tweetsParams = new List<TweetParams>();
            this.sentiments= new Sentiments();
		}

        public void addTweet(Tweet tweet)
		{
            this.tweets.Add(tweet);
            tweetsParams.Add(new TweetParams("WA", 0)); // TODO
		}

        public int length()
		{
            return tweets.Count();
		}

        public double caclulateHappines(Tweet tweet)
        {
            StringBuilder phrase = new StringBuilder();
            double weight = 0;
            foreach (var word in tweet.message)
            {
                if (word.Length==1 && char.IsPunctuation(Convert.ToChar(word)) && !string.IsNullOrEmpty(phrase.ToString()))
                {
                    phrase.Remove(phrase.Length - 1, 1);
                    if(phrase[0]==' ')
                    {
                        phrase.Remove(0, 1);
                    }
                    StringBuilder cutPhrase = new StringBuilder(string.Copy(phrase.ToString())); //фраза до знака пунктуации
                    for (int i = 0; i < cutPhrase.Length; i++)
                    {
                        StringBuilder changePhrase = new StringBuilder(string.Copy(cutPhrase.ToString())); //сохраняем cutPhrase для обрезания 
                        for (int j = 0; j < changePhrase.Length; j++)
                        {
                            weight += sentiments.GetWeight(changePhrase.ToString());
                            int indexOfLastSpace = changePhrase.ToString().LastIndexOf(' ');
                            if (indexOfLastSpace < 0) indexOfLastSpace = 0;
                            changePhrase.Remove(indexOfLastSpace,changePhrase.Length-indexOfLastSpace);
                            //здесь отрезаем последнее слово в фразе changePhrase
                        }
                        int indexOfFirstSpace = cutPhrase.ToString().IndexOf(' ');
                        if (indexOfFirstSpace < 0) indexOfFirstSpace = cutPhrase.Length - 1;
                        cutPhrase.Remove(0,indexOfFirstSpace + 1);
                        //здесь отрезаем первое слово у cutPhrase
                    }
                    phrase.Clear();
                }
                else
                {
                    phrase.Append(word + " ");
                    if (word.Length == 1 && char.IsPunctuation(Convert.ToChar(word)))
                    {
                        phrase.Clear();
                    }
                }
            }
            return weight;
        }

        public Tweet getTweet(int index)
		{
            if(index<0 || index > tweets.Count())
			{
                throw new TwitterTrendsException("Invalid index for getting tweet in database:" + index);
			}
            return tweets.ElementAt(index);
		}

        public TweetParams getTweetParams(int index)
        {
            if (index < 0 || index > tweets.Count())
            {
                throw new TwitterTrendsException("Invalid index for getting tweet params in database:" + index);
            }
            return tweetsParams.ElementAt(index);
        }

    }
}
