﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_trends
{
	public class Tweet
	{
		public Location location { get; }
		public DateTime timeOfCreation { get; }
		public List<string> message { get; }

		public Tweet() { }

		public Tweet(Location location)
		{
			this.location = location;
		}
		public Tweet(Location location, DateTime timeOfCreation, List<string> message)
		{
			this.location = location;
			this.timeOfCreation = timeOfCreation;
			this.message = message;
		}

		public void Out() // test method, should be removed
		{
			Console.WriteLine(location.latitude);
			Console.WriteLine(location.longtitude);
			Console.WriteLine(timeOfCreation.ToString());
			string mess = "";
			for(int i = 0; i < message.Count; i++)
			{
				mess += message[i] + ' ';
			}
			Console.WriteLine(mess);
		}
	}
}
