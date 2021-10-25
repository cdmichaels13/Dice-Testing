using System;
using System.Collections.Generic;

namespace Dice_Testing
{
    public class Roller
    {
        int _numOfDice;
        int _numOfSides;
        bool _exploding;
        const int _tests = 100000;

        public Roller(int numOfDice, int numOfSides, bool exploding)
        {
            _numOfDice = numOfDice;
            _numOfSides = numOfSides;
            _exploding = exploding;
        }

        public int[][] RollSet(Random random)
        {
            int[][] rolledSets = new int[_tests][];

            for(int i = 0; i < rolledSets.GetLength(0); i++)
            {
                List<int> buildingSubset = new List<int>();
                for (int j = 0; j < _numOfDice; j++)
                {
                    int rollResult;
                    do
                    {
                        rollResult = random.Next(1, _numOfSides + 1);
                        buildingSubset.Add(rollResult);
                    } while (rollResult == _numOfSides && _exploding);
                }
                rolledSets[i] = buildingSubset.ToArray();
            }

            return rolledSets;
        }
    }
}
