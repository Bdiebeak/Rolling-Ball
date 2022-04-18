using UnityEngine;

namespace RollingBall.Helpers.Patterns
{
    [DefaultExecutionOrder(-900)]
    public class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviourSingleton<T>
    {
        public static T Instance { get; private set; }

        public virtual void Awake() => AssignSingleton();
        protected virtual void AssignSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Debug.LogWarning($"Trying to assigning a singleton twice: {typeof(T).Name}. {gameObject.name} was destroyed.");
                Destroy(gameObject);
            }
            else Instance = GetComponent<T>();
        }

        protected virtual void OnDestroy()
        {
            if (this == Instance) Instance = null;
        }
    }

}
