using Player;
using UnityEngine;

public class StatDisplay : MonoBehaviour
{

    // Singleton
    private static StatDisplay instance = null;
    public static StatDisplay Instance { get => instance; }
    private void Awake(){
        if (instance == null){
            instance = this;
        } else {
            Destroy(this);
        }
    }

    [SerializeField] private InputReader inputReader;
    [SerializeField] private GameObject cardboard;
    [SerializeField] private TMPro.TextMeshProUGUI equipmentName;
    [SerializeField] private TMPro.TextMeshProUGUI content;
    [SerializeField] private TMPro.TextMeshProUGUI value;
    
    public void Show(bool show = true)
    {
        cardboard.SetActive(show);
    }

    public void LoadStats(Ship.Equipment equipment)
    {
        equipmentName.text = equipment.Name;
        content.text = equipment.DataToString();
        value.text = equipment.Value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().position = inputReader.GetMousePosition() + new Vector2(1,1);
    }
}
