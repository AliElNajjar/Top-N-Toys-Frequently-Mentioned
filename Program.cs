using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top_N_Toys_Frequently_Mentioned
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> toys = new List<string>() { "Drone", "elsa", "legos", "elmo", "tablet", "warcraft" };

            List<string> quotes = new List<string>() {"Elmo is the hottest of the season! it will be on every kid's wishlist!",
                                                      "The new Elmo dolls are super high quality",
                                                      "Expect the Elsa dolls to be very popular this year",
                                                      "Elsa and Elmo are the toys I'll be buying for my kids",
                                                      "For parents of older kids, look into buying them a drone",
                                                      "Warcraft is slowly rising in popularity ahead of the holiday season"};


            var topNToys = GetTopNToys(2, toys, quotes);

            Console.WriteLine(topNToys.SequenceEqual(new List<string>() { "elmo", "elsa" }));

            Console.ReadKey();
        }

        public static List<string> GetTopNToys(int topToysNum, List<string> toys, List<string> quotes)
        {
            List<string> totalTopNtoys = new List<string>();
            string topToy = string.Empty;

            for (int i = 0; i < toys.Count; i++)
            {
                toys[i] = toys[i].ToLower();
            }

            topToy = GetTopToy(toys, quotes);
            totalTopNtoys.Add(topToy);
  
            if (totalTopNtoys.Count == topToysNum)
            {
                for (int i = 0; i < totalTopNtoys.Count; i++)
                {
                    Console.WriteLine(totalTopNtoys[i]);
                }
                return totalTopNtoys;
            }

            while (totalTopNtoys.Count < topToysNum)
            {
                toys.Remove(topToy);
                topToy = GetTopToy(toys, quotes);
                if (topToy == string.Empty)
                {
                    break;
                }
                totalTopNtoys.Add(topToy);
            }

            for (int i = 0; i < totalTopNtoys.Count; i++)
            {
                Console.WriteLine(totalTopNtoys[i]);
            }
            
            return totalTopNtoys;
        }

        private static string GetTopToy(List<string> toys, List<string> quotes)
        {
            string topToy = string.Empty;
            string toyToCompare;
            string titleToCompare;
            int count = 0;
            int prevCount = 0;
            for (int i = 0; i < toys.Count; i++)
            {

                toyToCompare = toys[i];//.ToLower();

                for (int j = 0; j < quotes.Count; j++)
                {
                    titleToCompare = quotes[j].ToLower();

                    if (titleToCompare.Contains(toyToCompare))
                    {
                        count++;
                    }
                }
                if (count > prevCount)
                {
                    prevCount = count;
                    count = 0;
                    topToy = toyToCompare;
                }
            }
            return topToy;
        }
    }
}