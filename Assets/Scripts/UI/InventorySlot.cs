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
    private Vector3 baseScale;

    private void Awake() {
        equipment = null;
        baseScale = transform.localScale;
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
        transform.DOScale(baseScale * 1.1f, 0.2f);
        if (!equipment) return;
        StatDisplay.Instance.LoadStats(equipment);
        StatDisplay.Instance.Show();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(baseScale, 0.2f);
        StatDisplay.Instance.Show(false);
    }
}
