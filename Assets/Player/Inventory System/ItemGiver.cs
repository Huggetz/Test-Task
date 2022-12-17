using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGiver : MonoBehaviour
{
    public ItemData _itemData;
    


    public void GiveItem()
    {
        
        Inventory._thisInventory.AddItem(_itemData);
        // Debug.Log($"{Inventory._thisInventory._inventory.ContainsKey(data)} contains key");
        // Debug.Log($"{Inventory._thisInventory._inventory.Values}");
    }

    public void TakeItem()
    {
        
        Inventory._thisInventory.RemoveItem(_itemData);
    }
}
