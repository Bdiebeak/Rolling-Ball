using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RollingBall.UI
{
    /// <summary> This class is used to fill Layout Group UI (e.g. Grid Layout Group) by required elements. </summary>
    [Serializable]
    public class LayoutGroupContent<TPrefab> where TPrefab : MonoBehaviour
    {
        [SerializeField] private TPrefab elementPrefab;
        [SerializeField] private Transform layoutGroupTransform;

        private List<TPrefab> _instantiatedElements = new List<TPrefab>();
        public IEnumerable<TPrefab> InstantiatedElements => _instantiatedElements;
        
        public event Action<int, TPrefab> ElementCreated;
        public event Action<int, TPrefab> BeforeElementDestroy;
        
        private void OnElementCreated(int index, TPrefab element) => ElementCreated?.Invoke(index, element);
        private void OnBeforeElementDestroy(int index, TPrefab element) => BeforeElementDestroy?.Invoke(index, element);
        
        public void CleanLayoutContent()
        {
            _instantiatedElements = layoutGroupTransform.GetComponentsInChildren<TPrefab>().ToList();
            ChangeElementsCount(0);
        }

        public void ChangeElementsCount(int requiredCount)
        {
            var currentCount = InstantiatedElements.Count();

            if (currentCount > requiredCount)
            {
                for (var i = InstantiatedElements.Count() - 1; i >= requiredCount; i--)
                {
                    OnBeforeElementDestroy(_instantiatedElements.IndexOf(_instantiatedElements[i]), _instantiatedElements[i]);
                    
                    UnityEngine.Object.Destroy(InstantiatedElements.ElementAt(i).gameObject);
                    _instantiatedElements.RemoveAt(i);
                }
            }
            else if (currentCount < requiredCount)
            {
                var difference = requiredCount - currentCount;
                for (var i = 0; i < difference; i++)
                {
                    var newElement = UnityEngine.Object.Instantiate(elementPrefab, layoutGroupTransform).GetComponent<TPrefab>();
                    _instantiatedElements.Add(newElement);
                    
                    OnElementCreated(_instantiatedElements.IndexOf(newElement), newElement);
                }
            }
        }
    }
}