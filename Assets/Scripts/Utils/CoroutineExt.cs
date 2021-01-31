using UnityEngine;

namespace Utils
{
    public static class CoroutineExt
    {
        public static void Stop(this Coroutine coroutine, MonoBehaviour behavior)
        {
            if(coroutine != null) behavior.StopCoroutine(coroutine);
        }
    }
}