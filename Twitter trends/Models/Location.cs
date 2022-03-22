using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_trends
{
	public class Location
	{

		public double latitude { get; } //x
		public double longtitude { get; } //y
		
		public Location(double latitude, double longtitude)
		{
			this.latitude = latitude;
			this.longtitude = longtitude;
		}
	}
}
