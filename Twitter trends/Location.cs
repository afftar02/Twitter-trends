using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_trends
{
	public class Location
	{
		public double longtitude { get; } //y
		public double latitude { get; } //x

		public Location(double longtitude, double latitude)
		{
			this.longtitude = longtitude;
			this.latitude = latitude;
		}
	}
}
