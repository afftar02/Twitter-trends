using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter_trends.Data;
using Twitter_trends.Models;
using Twitter_trends.Services.Parsers;
using Twitter_trends.Services.Readers;


namespace Twitter_trends
{
	public class TweetService
	{
		private static Sentiments sentiments = new Sentiments();

        public static double caclulateHappines(List<string> message)
        {
            StringBuilder phrase = new StringBuilder();
            double weight = 0;
            foreach (var word in message)
            {
                if (word.Length == 1 && char.IsPunctuation(Convert.ToChar(word)) && !string.IsNullOrEmpty(phrase.ToString()))
                {
                    phrase.Remove(phrase.Length - 1, 1);
                    if (phrase[0] == ' ')
                    {
                        phrase.Remove(0, 1);
                    }
                    StringBuilder cutPhrase = new StringBuilder(string.Copy(phrase.ToString())); //фраза до знака пунктуации
                    for (int i = 0; i < cutPhrase.Length; i++)
                    {
                        StringBuilder changePhrase = new StringBuilder(string.Copy(cutPhrase.ToString())); //сохраняем cutPhrase для обрезания 
                        for (int j = 0; j <= changePhrase.Length; j++)
                        {
                            weight += sentiments.GetWeight(changePhrase.ToString());
                            int indexOfLastSpace = changePhrase.ToString().LastIndexOf(' ');
                            if (indexOfLastSpace < 0) indexOfLastSpace = 0;
                            changePhrase.Remove(indexOfLastSpace, changePhrase.Length - indexOfLastSpace);
                            //здесь отрезаем последнее слово в фразе changePhrase
                        }
                        int indexOfFirstSpace = cutPhrase.ToString().IndexOf(' ');
                        if (indexOfFirstSpace < 0) indexOfFirstSpace = cutPhrase.Length - 1;
                        cutPhrase.Remove(0, indexOfFirstSpace + 1);
                        //здесь отрезаем первое слово у cutPhrase
                    }
                    phrase.Clear();
                }
                else
                {
                    phrase.Append(word + " ");
                    if (word.Length == 1 && char.IsPunctuation(Convert.ToChar(word)))
                    {
                        phrase.Clear();
                    }
                }
            }
            return weight;
        }
        public static string GetStateByLocation(Location loc)
        {
            foreach (var state in DataBase.states)
            {
                foreach (var pol in state.Polygons)
                {
                    if (Polygon.IsInside(pol, loc))
                    {
                        return state.Name;
                    }
                }
            }
            return "UNKNOWN";
        }
    }
}
