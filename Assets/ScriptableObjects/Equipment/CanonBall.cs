using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ship
{
    public class CanonBall :MonoBehaviour
    {
        [SerializeField] private int damage;
        public int Damage { get => damage; set => damage = value;}

        public FModEvent eventHit;
        public FModEvent eventMiss;
        
        [HideInInspector] public Vector3 direction;
        [HideInInspector] public float speed;
        [HideInInspector] public int range = 10;
        private float distance = 0;
        private float speedModifier = 1;
        private float internalCounter = 0;

        private void OnTriggerEnter2D(Collider2D other) {
            Fighter fighter = other.GetComponent<Fighter>();
            if (fighter == null) return;
            fighter.Damage(damage);
            eventHit.PlayOneShotAttached(gameObject);
            Destroy(this.gameObject);
        }

        private void Update() {
            if (distance >= range) FallOutOfRange();
            if (distance >= range * 0.6) 
            {
                internalCounter += Time.deltaTime * 10;   
                speedModifier = Mathf.Lerp(1, 0.2f, internalCounter);
            }
            transform.position += (direction * (speed * Time.deltaTime * speedModifier));
            distance += speed * Time.deltaTime;
        }

        private void FallOutOfRange() {
            Debug.Log("Splash !");
            eventMiss.PlayOneShotAttached(gameObject);
            Destroy(this.gameObject);  
        }
    }
}