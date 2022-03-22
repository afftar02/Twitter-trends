using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_trends.Models
{
    public class Sentiment
    {
        private string text;
        private double value;

        public string Text { get { return text; } set { text = value; } }
        public double Value { get { return value; } set { this.value = value; } }

        public Sentiment()
        {

        }
        public Sentiment(string text, double value)
        {
            Text = text;
            Value = value;
        }
    }
}
