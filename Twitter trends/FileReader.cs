using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_trends
{
	class FileReader : IReader
	{

		public string[] Read(string filePath)
		{
			try
			{
				string[] lines = System.IO.File.ReadAllLines(filePath);
				return lines;
			}
			catch(Exception e)
			{
				Console.WriteLine(e.ToString());
				return new string[0];
			}
		}
	}
}
