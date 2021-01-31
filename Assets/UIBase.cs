using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI goldScore; 
    [SerializeField] private TMPro.TextMeshProUGUI legendScore;

    public void RefreshGoldScore(int score)
    {
        goldScore.text = score.ToString();
    }

    public void RefreshLegendScore(int score)
    {
        legendScore.text = score.ToString();
    }
}
