using UnityEngine;

namespace Utils
{
    public static class VectorExt
    {
        public static bool IsNearlyEqual(this Vector2 a, Vector2 b, float epsilon = 0.001f)
        {
            return (b - a).sqrMagnitude < epsilon * epsilon;
        }
    }
}