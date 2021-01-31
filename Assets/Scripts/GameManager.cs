using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton 
    private static GameManager instance = null;
    public FModEvent ambient;
    public FModEvent exploration;
    public FModEvent docked;
    
    private void Awake(){
        if (instance == null){
            instance = this;
        } else {
            Destroy(this);
        }
    }

    private void Start()
    {
        ambient?.Play();
        docked?.Stop();
        exploration?.Play();
    }

    public void EnterIslandMode()
    {
        PlayerController player = PlayerController.Instance;
        player.enabled = false;
        player.directionCursor.Show(false);
        docked?.Play();
        exploration?.Stop();

    }

    public void EnterExploMode()
    {
        docked?.Stop();
        exploration?.Play();
        PlayerController player = PlayerController.Instance;
        player.enabled = true;
        player.directionCursor.Show(true);
    }

}
