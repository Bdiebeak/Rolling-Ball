using UnityEngine;

namespace RollingBall.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasGroupPanel : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;

        private void Awake() => InitializeCanvasGroup();
        private void InitializeCanvasGroup()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void ActivateCanvasGroup()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }

        public void DeactivateCanvasGroup()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}