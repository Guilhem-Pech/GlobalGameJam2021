using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ship
{
    public class InventorySystem : MonoBehaviour
    {
        [SerializeField] private int maxSlots;
        public int MaxSlots
        {
            get => maxSlots;
        }

        // Singleton
        private static InventorySystem instance = null;
        private void Awake(){
            if (instance == null){
                instance = this;
            } else {
                Destroy(this);
            }
        }

        private void Start() {
            GameManager.Instance.UpdateScore();
            if(equipments == null) equipments = new List<Equipment>(10);
        }

        public List<Equipment> equipments;
        private int _gold;
        public int gold { get => _gold; }
        private int _legend;
        public int legend { get => _legend; }

        public void AddGold(int score)
        {
            _gold += score;
            GameManager.Instance.UpdateScore();            
        }

        public void AddLegend(int score)
        {
            _legend += score;
            GameManager.Instance.UpdateScore();            
        }

        public bool AddItem(Equipment equipment)
        {
            if (equipments.Count >= maxSlots) return false;
            return true;
        }

    }
}
