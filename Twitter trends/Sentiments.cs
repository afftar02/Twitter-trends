using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_trends
{
    class Sentiments
    {
        public string Content { get; }
        public int ContentWeight { get; }
        public Sentiments() { }
        public Sentiments(string content, int weight)
        {
            this.Content = content;
            this.ContentWeight = weight;
        }
        public void Output()
        {
            Console.WriteLine("Content: " + '"' + Content + '"' + " Weight: " + ContentWeight);
        }
    }
}
