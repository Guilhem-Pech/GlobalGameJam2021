using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static String baseSpritePath = "Sprites/UIMask";
    private Ship.Equipment equipment;
    public Ship.Equipment Equipment
    {
        get => equipment;
        set
        {
            equipment = value;
            UpdateSprite();
        }
    }

    private void Start() {
        equipment = null;
    }

    public void UpdateSprite()
    {
        if (equipment == null)
        {
            GetComponent<Image>().sprite = Resources.Load<Sprite>(baseSpritePath);
            return;
        }
        GetComponent<Image>().sprite = equipment.Sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.4f);
        if (!equipment) return;
        Debug.Log("hell");
        StatDisplay.Instance.LoadStats(equipment);
        StatDisplay.Instance.Show();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StatDisplay.Instance.Show(false);
    }
}
