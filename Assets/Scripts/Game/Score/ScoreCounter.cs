using System.Collections;
using UnityEngine;

namespace RollingBall.Game.Score
{
    public class ScoreCounter : MonoBehaviour
    {
        private float _currentScore;
        private Coroutine _currentCountingCoroutine;

        public float CurrentScore => _currentScore;

        public void StartCount()
        {
            if (_currentCountingCoroutine != null) return;

            _currentCountingCoroutine = StartCoroutine(CountingCoroutine());
        }

        public void StopCount()
        {
            if (_currentCountingCoroutine == null) return;

            StopCoroutine(_currentCountingCoroutine);
            _currentCountingCoroutine = null;
        }

        private IEnumerator CountingCoroutine()
        {
            while (true)
            {
                _currentScore += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}