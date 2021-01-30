using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ship
{
    public class CanonBall : MonoBehaviour
    {
        [SerializeField] private int damage;
        public int Damage { get => damage; }

        [HideInInspector] public Vector3 direction;
        [HideInInspector] public float speed;
        [HideInInspector] public int range = 10;
        private float distance = 0;
        private float speedModifier = 1;
        private float internalCounter = 0;

        private void OnTriggerEnter2D(Collider2D other) {
            Fighter fighter = other.GetComponent<Fighter>();
            if (fighter == null) return;
            Debug.Log("Collision with Fighter");
            fighter.Damage(damage);
            Destroy(this.gameObject);
        }

        private void Update() {
            if (distance >= range) FallOutOfRange();
            if (distance >= range * 0.6) 
            {
                internalCounter += Time.deltaTime * 10;   
                speedModifier = Mathf.Lerp(1, 0.2f, internalCounter);
            }
            transform.position = transform.position + (direction * speed * Time.deltaTime * speedModifier);
            distance += speed * Time.deltaTime;
        }

        private void FallOutOfRange() {
            Debug.Log("Splash !");
            Destroy(this.gameObject);  
        }
    }
}