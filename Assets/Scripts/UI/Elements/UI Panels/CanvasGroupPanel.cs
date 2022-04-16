using UnityEngine;

namespace RollingBall.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasGroupPanel : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;

        private void OnValidate() => CacheRequiredComponents();
        private void CacheRequiredComponents() => _canvasGroup = GetComponent<CanvasGroup>();

        [ContextMenu("Activate")]
        public void ActivateCanvasGroup()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }

        [ContextMenu("Deactivate")]
        public void DeactivateCanvasGroup()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}