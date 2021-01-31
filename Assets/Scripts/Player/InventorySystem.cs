using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ship
{
    public class InventorySystem : MonoBehaviour
    {
        // Singleton
        private static InventorySystem instance = null;
        private void Awake(){
            if (instance == null){
                instance = this;
            } else {
                Destroy(this);
            }
        }

        public List<Equipment> equipments;
        public int gold;
        public int legend;

        public GameObject CreateEquipment(Equipment equipment)
        {
            GameObject gameObject = Instantiate(equipment.gameObject, transform.position, Quaternion.identity);
            return gameObject;
        }

    }
}
