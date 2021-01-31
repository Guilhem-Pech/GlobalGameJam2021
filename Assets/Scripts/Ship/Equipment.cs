using System;
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

        public abstract String Name
        {
            get;
            set;
        }

        public abstract Sprite Sprite
        {
            get;
        }

        public abstract String DataToString(); 
        public abstract void DoAction();
        
    }
}