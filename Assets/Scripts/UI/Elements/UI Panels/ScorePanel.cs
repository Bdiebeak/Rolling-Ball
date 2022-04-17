using System.Linq;
using RollingBall.Helpers;
using UnityEngine;

namespace RollingBall.UI
{
    public class ScorePanel : CanvasGroupPanel
    {
        [Space]
        [SerializeField] private ScoreDataFiller highestScoreFiller;
        [SerializeField] private ScoreDataLayoutGroup scoreDataLayoutGroup;

        private void Start()
        {
            var allScores = UnitOfWork.Instance.ScoreRepository.GetAll().ToList();
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