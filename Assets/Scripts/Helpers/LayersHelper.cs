using UnityEngine;

namespace RollingBall.Helpers
{
    public static class LayersHelper
    {
        public static bool HasLayer(this LayerMask layerMask, int requiredLayer)
        {
            return layerMask == (layerMask | (1 << requiredLayer));
        }
    }
}