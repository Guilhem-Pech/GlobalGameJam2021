using UnityEngine;

namespace Ship
{
    public abstract class EquipmentHandler : MonoBehaviour
    {
        public abstract void DoAction();
        public abstract Equipment Equipment { get; set; }
    }
}
