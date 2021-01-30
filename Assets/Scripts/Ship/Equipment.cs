using UnityEngine;

namespace Ship
{
    [CreateAssetMenu(fileName = "Default", menuName = "Game/Equipment/Default", order = 0)]
    public class Equipment : ScriptableObject
    {
        public GameObject mesh;
        public Vector3 offset = Vector3.zero;
        
        public void DoAction()
        {
            Debug.Log("FIRE IN THE HOLE");
        }
        
    }
}