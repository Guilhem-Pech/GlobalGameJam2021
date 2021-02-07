using System;
using UnityEngine;

namespace Ship
{
    public class EquipmentSlot : MonoBehaviour
    {
        public Equipment equipment;
        private EquipmentHandler equipmentHandler;

        private void Start()
        {
            if(equipment != null)
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
            equipmentHandler = Instantiate(equipment.Prefab, transform).GetComponent<EquipmentHandler>();
            equipmentHandler.Equipment = equipment;
            equipmentHandler.gameObject.layer = 6;
        }
 
        public void DoAction()
        {
            if(equipment != null)
                equipmentHandler.DoAction();
        }
        
    }
}