using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIZoom : MonoBehaviour
{
    [SerializeField] private GameObject Boat;
    [SerializeField] private GameObject Island;
    [SerializeField] private GameObject Inventory;

    private void Start() {
        Hide();
    }

    public void Hide()
    {
        // Tweening
        

        // Deactivate
        Boat.SetActive(false);
        Island.SetActive(false);
        Inventory.SetActive(false);
    }

    public void Show()
    {
        // Activate
        Boat.SetActive(true);
        Island.SetActive(true);
        Inventory.SetActive(true);

        // Tweening
        Boat.transform.DOPunchScale(new Vector3(1,1,1), 0.5f);

    }
}
