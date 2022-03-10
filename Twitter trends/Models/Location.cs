using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_trends
{
	class Location
	{
		public double longtitude { get; }
		public double latitude { get; }

		public Location(double longtitude, double latitude)
		{
			this.longtitude = longtitude;
			this.latitude = latitude;
		}
	}
}
