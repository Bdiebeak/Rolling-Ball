using System.Linq;
using RollingBall.Game.Score;
using UnityEngine;

namespace RollingBall.UI
{
    public class ScorePanel : CanvasGroupPanel
    {
        [SerializeField] private ScoreDataFiller _highestScoreFiller;
        [SerializeField] private ScoreDataLayoutGroup _scoreDataLayoutGroup;
        
        private IScoreRepository _repository;

        private void Start()
        {
            _repository = new ScoreRepository(new ScorePlayerPrefsProvider());

            var allScores = _repository.GetAll().ToList();
            var orderedScores = allScores.OrderByDescending(x => x.DateTime);
            _scoreDataLayoutGroup.RefillLayoutGroup(orderedScores);
            
            if (allScores.Count != 0)
            {
                var highestScore = allScores.OrderByDescending(x => x.Score).First();
                _highestScoreFiller.UpdateText(highestScore);
            }
        }
    }
}