using System;
using UnityEngine;

namespace Ship
{
    [CreateAssetMenu(menuName = "Equipment/Pike")]
    public class Pike : Equipment
    {
        // Implement Equipment
        [SerializeField] private int value = 10;
        public override int Value { get => value; protected set => this.value = value; }
        [SerializeField] private String _name = "Basic Pike";
        public override String Name { get => _name; set => _name = value; }
        [SerializeField] private Sprite sprite;
        public override Sprite Sprite { get => sprite; }
        
        // For the PikeHandler
        public int damage = 20;
        public float damageRate = 4;

        [SerializeField] private GameObject prefab;
        public override GameObject Prefab { get => prefab; set => prefab = value; }
        
        public override String DataToString()
        {
            String data = "";
            data += $"Damage Per Second: {damage.ToString()}";
            return data;
        }
    }
}