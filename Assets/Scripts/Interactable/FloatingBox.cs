using System;
using UnityEngine;

namespace Interactable
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class FloatingBox : MonoBehaviour
    {
        private BoxCollider2D _trigger;
        [SerializeField] private int goldInside;
        public int GoldValue => goldInside;

        private void OnEnable()
        {
            _trigger = GetComponent<BoxCollider2D>();
            _trigger.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out Pawn pawn)) return; //If it's not a ship, do nothing
            pawn.GoldPossessed += goldInside;
            Destroy(gameObject);
        }
    }
}