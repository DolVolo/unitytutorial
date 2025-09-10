using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;
    public Transform itemsParent;

    Inventory inventory;



    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        inventoryUI.SetActive(!inventoryUI.activeSelf);

        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
        UpdateUI();
    }
    public void UpdateUI()
    {
        InventorySlot[] slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }




}
