﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class YatzyScorer
    {
        public static int CalculateScore(IEnumerable<int> dice, Category category)
        {
            if (dice.Any(x => x <= 0 || x > 6))
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
                Category.Pairs => ScorePairs(dice),
                Category.TwoPairs => ScoreTwoPairs(dice),
                Category.ThreeOfAKind => ScoreThreeOfAKind(dice),
                _ => throw new ArgumentException()
            };
        }

        private static int ScoreThreeOfAKind(IEnumerable<int> dice)
        {
            var triples = dice.GroupBy(x => x)
                .Where(g => g.Count() > 2)
                .Select(y => y.Key);
            return triples.Any() ? triples.First() * 3 : 0;
        }

        private static int ScoreTwoPairs(IEnumerable<int> dice)
        {
            var duplicate = dice.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key);
            return duplicate.Count() > 1 ? duplicate.Sum() * 2 : 0;
        }

        private static int ScorePairs(IEnumerable<int> dice)
        {
            var duplicate = dice.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key);
            return duplicate.Any() ? duplicate.Max() * 2 : 0;
        }

        private static int ScoreMultiples(IEnumerable<int> dice, Category category)
        {
            return dice.Where(x => x == (int) category).Sum();
        }

        private static int ScoreTwos(IEnumerable<int> dice)
        {
            return dice.Where(x => x == 2).Sum();
        }

        private static int ScoreOnes(IEnumerable<int> dice)
        {
            return dice.Where(x => x == 1).Sum();
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
