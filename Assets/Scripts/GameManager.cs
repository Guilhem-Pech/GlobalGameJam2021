using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    private static GameManager instance = null;
    public static GameManager Instance { get => instance; }
    private void Awake(){
        if (instance == null){
            instance = this;
        } else {
            Destroy(this);
        }
    }

    [SerializeField] private UIZoom islandUI;
    [SerializeField] private Cinemachine.CinemachineVirtualCamera islandCamera;

    public void EnterIslandMode()
    {
        PlayerController player = PlayerController.Instance;
        player.directionCursor.Show(false);
        islandUI.Show();
        islandCamera.Priority = 10;
        player.enabled = false;
    }

    public void EnterExploMode()
    {
        PlayerController player = PlayerController.Instance;
        player.enabled = true;
        // player.directionCursor.Show(true);
        islandUI.Hide();
        islandCamera.Priority = 0;
    }

}
