using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Testing
{
    public class Analyzer
    {
        private StringBuilder analysis = new StringBuilder();

        public Analyzer(int[][] set, int successValue)
        {
            SortedDictionary<int, int> successesTotals = new SortedDictionary<int, int>();

            for (int i = 0; i < set.GetLength(0); i++)
            {
                int successes = 0;
                foreach (int roll in set[i])
                {
                    if (roll >= successValue)
                        successes++;
                }

                if (!successesTotals.ContainsKey(successes))
                    successesTotals.Add(successes, 1);
                else
                    successesTotals[successes]++;
            }

            analysis.Append("Success Count Chances\n");
            double totalChance = 100;
            foreach (var successTotal in successesTotals)
            {
                double chance = Convert.ToDouble(successTotal.Value) / Convert.ToDouble(100000) * 100;
                chance = Math.Round(chance, 2);
                analysis.Append(successTotal.Key + ": " + chance + "%, " + Math.Round(totalChance, 2) + "%\n");
                totalChance -= chance;
            }

            double averageSuccesses = 0;
            foreach (var successTotal in successesTotals)
            {
                averageSuccesses += successTotal.Key * successTotal.Value;
            }
            averageSuccesses /= 100000;
            analysis.Append("Average number of successes = " + Math.Round(averageSuccesses, 2) + "\n");
        }

        public string SendResults()
        {
            return analysis.ToString();
        }
    }
}
