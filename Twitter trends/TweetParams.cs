using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_trends
{
	class TweetParams
	{
		private string locationState { get; set; }
		private double happiness { get; set; }

		public TweetParams(string locationState, double happiness)
		{
			this.locationState = locationState;
			this.happiness = happiness;
		}

	}
}
