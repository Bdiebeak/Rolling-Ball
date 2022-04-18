using System;
using RollingBall.Game.Score;
using RollingBall.Helpers;
using RollingBall.UI;
using UnityEngine;

namespace RollingBall.Game.Logic
{
    public class GameLogic : MonoBehaviour
    {
        [SerializeField] private TriggerHandler startHandler;
        [SerializeField] private TriggerHandler finishHandler;
        [SerializeField] private TriggerHandler gameOverHandler;
        [Space]
        [SerializeField] private CurrentScorePanel currentScorePanel;
        [SerializeField] private FinishPanel finishPanel;
        [SerializeField] private CanvasGroupPanel gameOverPanel;
        [Space]
        [SerializeField] private ScoreCounter scoreCounter;
        
        private void OnEnable() => SubscribeOnRequiredEvents();
        private void SubscribeOnRequiredEvents()
        {
            startHandler.entered += OnStartHandler;
            finishHandler.entered += OnFinishHandler;
            gameOverHandler.entered += OnGameOverHandler;
        }

        private void OnDisable() => UnsubscribeOnRequiredEvents();
        private void UnsubscribeOnRequiredEvents()
        {
            startHandler.entered -= OnStartHandler;
            finishHandler.entered -= OnFinishHandler;
            gameOverHandler.entered -= OnGameOverHandler;
        }
        
        private void OnStartHandler(GameObject enteredObject)
        {
            scoreCounter.StartCount();

            currentScorePanel.scoreCounter = scoreCounter;
            currentScorePanel.ActivateCanvasGroup();
            finishPanel.DeactivateCanvasGroup();
            gameOverPanel.DeactivateCanvasGroup();
        }
        
        private void OnFinishHandler(GameObject enteredObject)
        {
            scoreCounter.StopCount();
            gameOverHandler.gameObject.SetActive(false);
            finishHandler.gameObject.SetActive(false);
            
            finishPanel.ChangeScoreText(scoreCounter.CurrentScore);
            finishPanel.ActivateCanvasGroup();
            currentScorePanel.DeactivateCanvasGroup();
            gameOverPanel.DeactivateCanvasGroup();
            
            UnitOfWork.Instance.ScoreRepository.Add(new ScoreData(scoreCounter.CurrentScore, DateTime.Now));
        }
        
        private void OnGameOverHandler(GameObject enteredObject)
        {
            scoreCounter.StopCount();

            gameOverPanel.ActivateCanvasGroup();
            currentScorePanel.DeactivateCanvasGroup();
            finishPanel.DeactivateCanvasGroup();
        }
    }
}