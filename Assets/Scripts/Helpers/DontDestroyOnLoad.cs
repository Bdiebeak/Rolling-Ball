using UnityEngine;

namespace RollingBall.Helpers
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake()
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
    }
}