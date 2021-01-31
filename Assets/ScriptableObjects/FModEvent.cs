using System;
using System.CodeDom;
using FMOD;
using FMOD.Studio;
using UnityEngine;

namespace ScriptableObjects
{
    [Serializable]
    public class FModEvent
    {
        [FMODUnity.EventRef] public string eventReference;
        public FMOD.Studio.EventInstance eventInstance;

        private void Stop()
        {
            if(eventInstance.isValid())
                eventInstance.stop(STOP_MODE.ALLOWFADEOUT);
        }

        public void CreateInstance()
        {
            eventInstance = FMODUnity.RuntimeManager.CreateInstance(eventReference);
        }

        public void AttatchToGameobject(GameObject go)
        {
            if(!eventInstance.isValid()) CreateInstance();
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(eventInstance, go.transform, go.GetComponent<Rigidbody2D>());
        }

        public RESULT Play(float pitch)
        {
            if(!eventInstance.isValid()) CreateInstance();
            eventInstance.setPitch(pitch);
            return Play();
        }

        public RESULT Play()
        {
            if(!eventInstance.isValid()) CreateInstance();
            return eventInstance.start();
        }

        public void PlayOneShot()
        {
            FMODUnity.RuntimeManager.PlayOneShot(eventReference);
        }
        
        
        
        
    }
}