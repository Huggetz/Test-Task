using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class InventoryItemScript : MonoBehaviour
{
    public ItemData _thisItem;
    public static event Wear WearThis;
    public delegate void Wear(ItemData item);

    private void OnEnable()
    {
        
    }

    public void SetImage()
    {
        transform.GetComponent<Image>().sprite = _thisItem._icon;
    }


    public void WearItem()
    {
        WearThis?.Invoke(_thisItem);
        Inventory._thisInventory.RemoveItem(_thisItem);

    }

    public void DestroyThis(ItemData item)
    {
        if (item == _thisItem)
        {
            if (_thisItem != null)
            {
                Destroy(transform.parent.gameObject);
            }
        }
        
    }

    private void OnDestroy()
    {
        
    }



}
