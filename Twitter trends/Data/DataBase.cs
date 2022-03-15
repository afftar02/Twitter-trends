using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_trends.Data
{
    class DataBase
    {
        private List<Tweet> tweets;
        private List<TweetParams> tweetsParams;

        public DataBase()
		{
            this.tweets = new List<Tweet>();
            this.tweetsParams = new List<TweetParams>();
		}

        public void addTweet(Tweet tweet)
		{
            this.tweets.Add(tweet);
            tweetsParams.Add(new TweetParams("WA", 0)); // TODO
		}
    }
}
