using System;
using UnityEngine;

namespace RollingBall.Helpers
{
    [RequireComponent(typeof(Collider))]
    public class TriggerHandler : MonoBehaviour
    {
        [SerializeField] private LayerMask triggerableLayers;

        public event Action<GameObject> entered;
        public event Action<GameObject> exited;

        private void OnTriggerEnter(Collider other)
        {
            var enteredObject = other.gameObject;
            if (triggerableLayers.HasLayer(enteredObject.layer)) entered?.Invoke(enteredObject);
        }

        private void OnTriggerExit(Collider other)
        {
            var enteredObject = other.gameObject;
            if (triggerableLayers.HasLayer(enteredObject.layer)) exited?.Invoke(enteredObject);
        }
    }
}