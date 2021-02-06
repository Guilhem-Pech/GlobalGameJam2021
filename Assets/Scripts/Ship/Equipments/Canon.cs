using System;
using UnityEngine;

namespace Ship
{
    [CreateAssetMenu(menuName = "Equipment/Canon")]
    public class Canon : Equipment
    {
        // Implement Equipment
        [SerializeField] private int value = 0;
        public override int Value { get => value; protected set => this.value = value; }
        [SerializeField] private String _name;
        public override String Name { get => _name; set => _name = value; }
        [SerializeField] private Sprite sprite;
        public override Sprite Sprite { get => sprite; }

        // For the CanonHandler
        public GameObject canonBallPrefab;
        public float velocity;
        public float fireRate = 0.5f;
        public int damage = 10;
        public int range = 100;
        public float ballScale = 1;

        [SerializeField] private GameObject prefab;
        public override GameObject Prefab { get => prefab; set => prefab = value; }

        public override string DataToString()
        {
            String data = "";
            data += $"Damage Per Canon Ball: {damage.ToString()}\n";
            data += $"Range: {range.ToString()}\n";
            data += $"Velocity: {velocity.ToString()}\n";
            data += $"Canon Ball Size: {ballScale.ToString()}\n";
            data += $"Rate of Fire: {fireRate.ToString()}\n";
            return data;
        }
    }
}
