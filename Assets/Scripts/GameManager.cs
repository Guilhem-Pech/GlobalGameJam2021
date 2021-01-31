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
    [SerializeField] private UIBase scoreUI;
    [SerializeField] private Cinemachine.CinemachineVirtualCamera islandCamera;
    public FModEvent docked;
    public FModEvent exploration;
    public FModEvent ambient;
    
    public void UpdateScore()
    {
        PlayerController player = PlayerController.Instance;
        Ship.InventorySystem inventory = player.GetComponent<Ship.InventorySystem>();
        scoreUI.RefreshGoldScore(inventory.gold);
        scoreUI.RefreshLegendScore(inventory.legend);
    }

    private bool isInExploMode = true;

    public void EnterIslandMode()
    {
        if(!isInExploMode) return;

        PlayerController player = PlayerController.Instance;
        player.directionCursor.Show(false);
        islandUI.Show();
        islandCamera.Priority = 10;
        player.enabled = false;
        exploration?.Stop();
        docked?.Play();
        
        isInExploMode = false;
    }

    public void EnterExploMode()
    {
        if(isInExploMode) return;

        PlayerController player = PlayerController.Instance;
        player.enabled = true;
        // player.directionCursor.Show(true);
        islandUI.Hide();
        islandCamera.Priority = 0;
        exploration?.Play();
        docked?.Stop();

        isInExploMode = true;
    }

    private void Start()
    {
        ambient?.Play();
        docked?.Stop();
        exploration?.Play();
    }
}
   

