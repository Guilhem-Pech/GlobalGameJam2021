using System;
using UnityEngine;

namespace Ship
{
    public abstract class Equipment: ScriptableObject
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

        public abstract GameObject Prefab
        { 
            get; 
            set;
        }

        public abstract String DataToString();
    }
}