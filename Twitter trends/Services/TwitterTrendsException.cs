using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_trends
{
	class TwitterTrendsException : Exception
	{
		public TwitterTrendsException()
		{
		}

		public TwitterTrendsException(string message)
			: base(message)
		{
		}

		public TwitterTrendsException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
