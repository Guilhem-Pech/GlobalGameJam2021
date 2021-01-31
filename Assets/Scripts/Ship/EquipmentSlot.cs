using System;
using UnityEngine;

namespace Ship
{
    public class EquipmentSlot : MonoBehaviour
    {
        public Equipment equipment;

        private void Start()
        {
            if(equipment)
                SpawnEquipment(equipment);
        }

        private void DeleteEquipment(bool deleteType = true)
        {
            for (int i = 0; i < transform.childCount; ++i)
            {
                Destroy(transform.GetChild(i));
            }
            if(deleteType) equipment = null;
        }
        
        public void SpawnEquipment(Equipment type)
        {
            DeleteEquipment();
            equipment = type; 
            equipment = Instantiate(equipment.gameObject, transform).GetComponent<Equipment>();
        }

        public void DoAction()
        {
            if(equipment)
                equipment.DoAction();
        }
        
    }
}