using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIZoom : MonoBehaviour
{
    [SerializeField] private GameObject Boat;
    [SerializeField] private GameObject Island;
    [SerializeField] private GameObject Inventory;

    [SerializeField] private RectTransform frontSlot;
    [SerializeField] private RectTransform backSlot;
    [SerializeField] private RectTransform rightSlot;
    [SerializeField] private RectTransform leftSlot;

    [SerializeField] private List<InventorySlot> inventorySlots;
    [SerializeField] private Sprite baseSprite;

    private void Start() {
        Hide();        
    }

    private void PopulateBoatSlots()
    {
        PlayerController player = PlayerController.Instance;
        Pawn pawn = player.pawn;

        Ship.Equipment frontEquipment = pawn.frontSlot.equipment;
        Ship.Equipment backEquipment = pawn.backSlot.equipment;
        Ship.Equipment leftEquipment = pawn.leftSlot.equipment;
        Ship.Equipment rightEquipment = pawn.rightSlot.equipment;

        frontSlot.GetComponent<InventorySlot>().Equipment = frontEquipment;
        backSlot.GetComponent<InventorySlot>().Equipment = backEquipment;
        leftSlot.GetComponent<InventorySlot>().Equipment = leftEquipment;
        rightSlot.GetComponent<InventorySlot>().Equipment = rightEquipment;
    }

    private void PopulateInventorySlots()
    {
        Ship.InventorySystem inventory = PlayerController.Instance.GetComponent<Ship.InventorySystem>();
        foreach (var equipment in inventory.equipments)
        {
            int i = 0;
            while (inventorySlots[i].Equipment != null)
                i++;
            inventorySlots[i].Equipment = equipment;
        }
    }

    private void EmptyInventorySlots()
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            slot.Equipment = null;
        }
    }

    public void Hide()
    {
        // Tweening
        Inventory.GetComponent<RectTransform>().DOAnchorPosX(-545, 0.5f);

        // Deactivate
        Boat.SetActive(false);
        Island.SetActive(false);
        EmptyInventorySlots();
        // Inventory.SetActive(false);
    }

    public void Show()
    {
        // Activate
        Boat.SetActive(true);
        Island.SetActive(true);
        PopulateBoatSlots();
        PopulateInventorySlots();
        // Inventory.SetActive(true);

        // Tweening
        Boat.transform.DOPunchScale(new Vector3(1,1,1), 0.5f);
        Inventory.GetComponent<RectTransform>().DOAnchorPosX(0, 0.5f);
    }
}
