using System;
using UnityEngine;

namespace Ship
{
    public class EquipmentSlot : MonoBehaviour
    {
        public Equipment equipmentType;

        private void Start()
        {
            if(equipmentType)
                SpawnEquipment(equipmentType);
        }


        private void DeleteEquipment(bool deleteType = true)
        {
            for (int i = 0; i < transform.childCount; ++i)
            {
                Destroy(transform.GetChild(i));
            }
            if(deleteType) equipmentType = null;
        }
        
        public void SpawnEquipment(Equipment type)
        {
            DeleteEquipment();
            equipmentType = type; 
            GameObject g = Instantiate(equipmentType.gameObject, transform);
        }

        public void DoAction()
        {
            if(equipmentType)
                equipmentType.DoAction();
        }
        
    }
}