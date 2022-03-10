using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_trends
{
	class Tweet
	{
		public Location location { get; }
		public DateTime timeOfCreation { get; }
		public string message { get; }

		public Tweet() { }
		public Tweet(Location location, DateTime timeOfCreation, string message)
		{
			this.location = location;
			this.timeOfCreation = timeOfCreation;
			this.message = message;
		}

		public void Out()
		{
			Console.WriteLine(location.latitude);
			Console.WriteLine(location.longtitude);
			Console.WriteLine(timeOfCreation.ToString());
			Console.WriteLine(message);
		}
	}
}
