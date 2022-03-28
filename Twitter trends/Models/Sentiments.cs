using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_trends
{
    class Sentiments
    {
        public Dictionary<string, double> sentiments = new Dictionary<string, double>();
        public Sentiments() 
        {
            string allLines = SentimentsReader.Read(@"..\..\Data\Resources\sentiments\sentiments.txt");
            string [] lines = allLines.Split('\n');
            foreach (string line in lines)
			{
                string[] parts = line.Split(',');
                sentiments.Add(parts[0],double.Parse(parts[1], CultureInfo.InvariantCulture));
			}
            
        }

        public void Output()
        {
            foreach (var item in sentiments)
            Console.WriteLine($"Content: {item.Key} Weight: {item.Value}");
        }

        public double GetWeight(string word)
        {
            double weight = 0;
            this.sentiments.TryGetValue(word, out weight);
            return weight;
        }
    }
}
