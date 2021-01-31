using System;
using UnityEngine;

namespace Ship
{
    public class Pike : Equipment
    {
        [SerializeField] private int value = 10;
        public override int Value { get => value; protected set => this.value = value; }
        [SerializeField] private String _name = "Basic Pike";
        public override String Name { get => _name; set => _name = value; }
        [Tooltip("Damage done per second, not per tic")]
        [SerializeField] private int damage = 20;
        public int Damage { get => damage; set => damage = value; }

        [SerializeField] private float counter = 0;
        [SerializeField] private float damageRate = 4;

        private static string spritePath = "Sprites/Pike";
        public override Sprite Sprite
        {
            get => Resources.Load<Sprite>(spritePath);
        }

        public override void DoAction()
        {
            return;
        }

        private void Update() {
            counter += Time.deltaTime;
        }

        private void OnTriggerStay2D(Collider2D other) 
        {
            Fighter fighter = other.GetComponent<Fighter>();
            if (fighter == null || counter < 1/damageRate) return;
            fighter.Damage(damage/damageRate);
            counter = 0;
        }

        public override String DataToString()
        {
            String data = "";
            data += $"Damage Per Second: {damage.ToString()}";
            return data;
        }
    }
}