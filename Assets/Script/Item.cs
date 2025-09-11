using System.Collections;
using System.Collections.Generic;   
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool showInventory = true;

    //คำสั่งกรณีใช้ไอเท็ม
    public void Use()
    {
        if (name == "Axe" && !PlayerMovement.instance.showAxe)
        {
            PlayerMovement.instance.ShowAxe();
            RemoveFromInventory();
        }
    }
    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
