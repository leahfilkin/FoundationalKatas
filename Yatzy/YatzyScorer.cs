using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class YatzyScorer
    {
        public IEnumerable<int> CountFaceValues(List<Die> dice)
        {
            var diceValues = new List<int>();
            foreach (var die in dice)
            {
                diceValues.Add(die.Face);
            }
            return diceValues;
        }
        public static int CalculateScore(IEnumerable<int> dice, Category category)
        {
            if (dice.Any(x => x < 1 || x > 6))
            {
                throw new ArgumentException
                    ("Die should only have values from 1 to 6");
            }

            if (dice.Count() != 5)
            {
                throw new ArgumentException
                    ("Should only have 5 dice");
            }
            return category switch
            {
                Category.Chance => ScoreChance(dice),
                Category.Yatzy => ScoreYatzy(dice),
                Category.Ones => ScoreMultiples(dice, Category.Ones),
                Category.Twos => ScoreMultiples(dice, Category.Twos),
                Category.Threes => ScoreMultiples(dice, Category.Threes),
                Category.Fours => ScoreMultiples(dice, Category.Fours),
                Category.Fives => ScoreMultiples(dice, Category.Fives),
                Category.Sixes => ScoreMultiples(dice, Category.Sixes),
                Category.Pairs => ScoreDuplicates(dice, 2),
                Category.TwoPairs => ScoreTwoPairs(dice),
                Category.ThreeOfAKind => ScoreDuplicates(dice, 3),
                Category.FourOfAKind => ScoreDuplicates(dice, 4),
                Category.SmallStraight => ScoreSmallStraight(dice),
                Category.LargeStraight => ScoreLargeStraight(dice),
                Category.FullHouse => ScoreFullHouse(dice),
                _ => throw new ArgumentException()
            };
        }

        private static Dictionary<int, int> GroupDice(IEnumerable<int> dice)
        {
            return dice.GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());
        }

        private static int ScoreFullHouse(IEnumerable<int> dice)
        {
            var threeOfAKind = GroupDice(dice)
                .FirstOrDefault(g => g.Value == 3);
            var pairs = GroupDice(dice)
                .FirstOrDefault(g => g.Value == 2);
            if (threeOfAKind.Key != 0 && pairs.Key != 0)
            {
                return threeOfAKind.Key * 3 + pairs.Key * 2;
            }
            return 0;
        }

        private static int ScoreLargeStraight(IEnumerable<int> dice)
        {
            var largeStraight = new [] {2, 3, 4, 5, 6};
            return dice.SequenceEqual(largeStraight) ? dice.Sum() : 0;
        }

        private static int ScoreSmallStraight(IEnumerable<int> dice)
        {
            var smallStraight = new [] {1, 2, 3, 4, 5};
            return dice.SequenceEqual(smallStraight) ? dice.Sum() : 0;
        }

        private static int ScoreDuplicates(IEnumerable<int> dice, int kind)
        {
            var duplicate = GroupDice(dice)
                .Where(x => x.Value >= kind);
            return duplicate.Any() ? duplicate.First().Key * kind : 0;
        }

        private static int ScoreTwoPairs(IEnumerable<int> dice)
        {
            var duplicate = dice.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key);
            return duplicate.Count() > 1 ? duplicate.Sum() * 2 : 0;
        }

        private static int ScoreMultiples(IEnumerable<int> dice, Category category)
        {
            return dice.Where(x => x == (int) category).Sum();
        }

        private static int ScoreChance(IEnumerable<int> dice)
        {
            return dice.Sum();
        }

        private static int ScoreYatzy(IEnumerable<int> dice)
        {
            var allTheSame = dice.GroupBy(x => x).Count() == 1;
            return allTheSame ? 50 : 0;
        }
    }
}
