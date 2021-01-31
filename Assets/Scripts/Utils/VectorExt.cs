using UnityEngine;

namespace Utils
{
    public static class VectorExt
    {
        public static bool IsNearlyEqual(this Vector2 a, Vector2 b, float epsilon = 0.001f)
        {
            return (b - a).sqrMagnitude < epsilon * epsilon;
        }
        
        public static bool IsNearlyEqual(this Vector3 a, Vector3 b, float epsilon = 0.001f)
        {
            return (b - a).sqrMagnitude < epsilon * epsilon;
        }

        public static float SqrDistance(this Vector2 a, Vector2 b)
        {
            return (b - a).SqrMagnitude();
        }
        
        public static float Distance(this Vector2 a, Vector2 b)
        {
            return Vector2.Distance(a, b);
        }
        
    }
}