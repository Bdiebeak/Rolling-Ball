using System.Linq;
using RollingBall.Game.Score;
using UnityEngine;

namespace RollingBall.UI
{
    public class ScorePanel : CanvasGroupPanel
    {
        [Space]
        [SerializeField] private ScoreDataFiller highestScoreFiller;
        [SerializeField] private ScoreDataLayoutGroup scoreDataLayoutGroup;
        
        // ToDo: unity of work may be?
        private IScoreRepository _repository;

        private void Start()
        {
            _repository = new ScoreRepository(new ScorePlayerPrefsProvider());

            var allScores = _repository.GetAll().ToList();
            var orderedScores = allScores.OrderByDescending(x => x.DateTime);
            scoreDataLayoutGroup.RefillLayoutGroup(orderedScores);
            
            if (allScores.Count != 0)
            {
                var highestScore = allScores.OrderByDescending(x => x.Score).First();
                highestScoreFiller.UpdateText(highestScore);
            }
        }
    }
}