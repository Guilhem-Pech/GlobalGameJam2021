using System;
using System.Collections;
using UnityEngine;
using Utils;

namespace Equipment
{
    public class GrapplingHook : MonoBehaviour
    {
        [SerializeField] private Transform endHook;
        private LineRenderer _hook;
        private Coroutine _launching;
        
        private void OnEnable()
        {
            endHook.TryGetComponent(out _hook);
        }

        public void Fire(Vector2 target)
        { 
            _launching.Stop(this);
            _launching = StartCoroutine(LaunchHook(target));

        }

        public IEnumerator LaunchHook(Vector2 target)
        {
            for (; !endHook.position.IsNearlyEqual(target, 0.01f);)
            {
                endHook.position = Vector3.MoveTowards(endHook.position, target, 1);   
                yield return null;
            }

            endHook.position = target;
        }

        private void OnDisable()
        {
            _launching.Stop(this);
        }

        private void Update()
        {
            Vector3[] positions = {transform.position, endHook.position};
            _hook.SetPositions(positions);
        }
    }
}