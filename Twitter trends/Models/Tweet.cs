using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter_trends.Models;

namespace Twitter_trends
{
	public class Tweet
	{
		public Location location { get; }
		public DateTime timeOfCreation { get; }
		public string message { get; }
		public string locationState { get; set; }
		public double happiness { get; set; }

		private Point pointOnMap;

		public Point PointOnMap { get { return pointOnMap; } set { pointOnMap = value; } }

		public Tweet() { }

		public Tweet(Location location)
		{
			this.location = location;
		}
		public Tweet(Location location, DateTime timeOfCreation, string message)
		{
			this.location = location;
			this.timeOfCreation = timeOfCreation;
			this.message = message;
			this.locationState = TweetService.GetStateByLocation(location);
			this.happiness = TweetService.caclulateHappines(TweetParser.MessageParser(message));
		}

        public override string ToString()
        {
			StringBuilder result = new StringBuilder();
            foreach (var word in message)
            {
				result.Append(word + " ");
            }
			return result.ToString();
        }
    }

    
}
