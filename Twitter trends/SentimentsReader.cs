﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_trends
{
    internal class SentimentsReader : IReader
    {
        public string Read(string filePath)
        {
			try
			{
				StringBuilder data = new StringBuilder("");
				string[] lines = System.IO.File.ReadAllLines(filePath);
				foreach (string line in lines)
				{
					data.Append(line + '\n');
				}
				data.Remove(data.Length - 1, 1);
				return data.ToString();
			}
			catch (Exception)
			{
				throw new Exception("Couldn't read from file: " + filePath);
			}
		}
    }
}
