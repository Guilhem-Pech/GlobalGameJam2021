using UnityEngine;

namespace Ship
{
    public abstract class Equipment : MonoBehaviour
    {

        public abstract int Value
        {
            get;
            protected set;
        }

        public abstract void DoAction();
        
    }
}