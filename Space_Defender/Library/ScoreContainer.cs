using System;
using System.Collections.Generic;
using System.Linq;

namespace Space_Defender.Library
{
    public static class ScoreContainer
    {
        private static readonly Dictionary<Players, double> scoringDictionary = new Dictionary<Players, double>(); 

        static ScoreContainer()
        {
            initialize();
        }

        private static void initialize()
        {
            var playerIndexes = (Players[]) Enum.GetValues(typeof (Players));
            foreach (var playerIndex in playerIndexes)
                scoringDictionary.Add(playerIndex, 0.0);
        }

        public static void ResetScores()
        {
            foreach (var score in scoringDictionary)
                scoringDictionary[score.Key] = 0.0;
        }

        public static void AddScore(this Player player, double score)
        {
            scoringDictionary[player.PlayerIndex] += score;
        }

        public static double GetScore(this Player player)
        {
            return scoringDictionary[player.PlayerIndex];
        }
    }
}
