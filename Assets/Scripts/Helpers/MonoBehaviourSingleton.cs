using UnityEngine;

namespace RollingBall.Helpers
{
    /// <summary>
    /// This is a helper class which could be used for automatically configure a singleton class.
    /// Inherit a class from this helper if you're creating a singleton.
    /// </summary>
    /// <typeparam name="T"> Singleton object's type. </typeparam>
    [DefaultExecutionOrder(-900)]
    public class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviourSingleton<T>
    {
        public static T Instance { get; private set; }

        public virtual void Awake() => AssignSingleton();
        protected virtual void AssignSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Debug.LogWarning($"Trying to assigning a singleton twice: {typeof(T).Name}.");
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
