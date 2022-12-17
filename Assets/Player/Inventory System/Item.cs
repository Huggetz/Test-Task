using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item
{
    public ItemData _itemData;

    public Item(ItemData data)
    {
        _itemData = data;
    }
    
}
