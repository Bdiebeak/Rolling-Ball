using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RollingBall.Game.Score
{
    public class ScorePlayerPrefsProvider : IScoreDataProvider
    {
        private const string CountKey = "Count";
        private const string ScoreKey = "Score";
        private const string DateTimeKey = "DateTime";
        
        public IEnumerable<ScoreData> Load()
        {
            var loadedScore = new List<ScoreData>();
            var savedCount = PlayerPrefs.GetInt(CountKey);
            for (var i = 0; i < savedCount; i++)
            {
                var savedScore = PlayerPrefs.GetFloat($"{ScoreKey}{i}");
                var savedDateTime = PlayerPrefs.GetString($"{DateTimeKey}{i}");
                
                loadedScore.Add(new ScoreData(savedScore, Convert.ToDateTime(savedDateTime)));
            }

            return loadedScore;
        }

        public void Save(IEnumerable<ScoreData> data)
        {
            var scores = data.ToList();
            var scoresCount = scores.Count();
            PlayerPrefs.SetInt(CountKey, scoresCount);

            for (var i = 0; i < scoresCount; i++)
            {
                var score = scores[i];
                PlayerPrefs.SetFloat($"{ScoreKey}{i}", score.Score);
                PlayerPrefs.SetString($"{DateTimeKey}{i}", score.DateTime.ToString());
            }
        }
    }
}