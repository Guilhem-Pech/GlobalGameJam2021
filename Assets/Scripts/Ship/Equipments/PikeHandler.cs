using UnityEngine;

namespace Ship
{
    public class PikeHandler : EquipmentHandler
    {
        [HideInInspector] public Pike pike;

        private float counter = 0; // cooldown

        public override Equipment Equipment { get => pike; set => pike = (Pike)value; }

        public override void DoAction()
        {
            return;
        }

        private void Start() {
            Transform[] children = GetComponentsInChildren<Transform>();
            foreach (Transform child in children)
            {
                child.gameObject.layer = gameObject.layer;
            }
        }

        public void Update() {
            counter += Time.deltaTime;
        }

        private void OnTriggerStay2D(Collider2D other) 
        {
            Fighter fighter = other.GetComponent<Fighter>();
            if (fighter == null || counter < 1/pike.damageRate) return;
            fighter.Damage(pike.damage/pike.damageRate);
            counter = 0;
        }
    }
}