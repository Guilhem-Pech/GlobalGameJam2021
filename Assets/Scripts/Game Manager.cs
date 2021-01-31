using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    private static GameManager instance = null;
    private void Awake(){
        if (instance == null){
            instance = this;
        } else {
            Destroy(this);
        }
    }

    public void EnterIslandMode()
    {
        PlayerController player = PlayerController.Instance;
        player.enabled = false;
        player.directionCursor.Show(false);

    }

    public void EnterExploMode()
    {
        PlayerController player = PlayerController.Instance;
        player.enabled = true;
        player.directionCursor.Show(true);
    }

}
