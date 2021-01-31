using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton 
    private static GameManager instance = null;
    public FModEvent ambient;
    
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
