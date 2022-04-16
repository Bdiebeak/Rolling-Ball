using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace RollingBall.UI
{
    [RequireComponent(typeof(LayoutGroup))]
    public abstract class CustomLayoutGroup <TData, TPrefab> : MonoBehaviour where TPrefab : MonoBehaviour
    {
        [SerializeField] protected LayoutGroupContent<TPrefab> content = new LayoutGroupContent<TPrefab>();

        protected virtual void Awake() => content.CleanLayoutContent();

        public virtual void RefillLayoutGroup(IEnumerable<TData> data)
        {
            var dataList = data.ToList();
            var elementsCount = dataList.Count;
            content.ChangeElementsCount(elementsCount);

            for (var i = 0; i < elementsCount; i++)
                OnElementCreated(content.InstantiatedElements.ElementAt(i), dataList[i]);
        }

        protected abstract void OnElementCreated(TPrefab element, TData data);
    }
}