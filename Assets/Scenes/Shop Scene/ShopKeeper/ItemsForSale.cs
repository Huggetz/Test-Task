using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsForSale : MonoBehaviour
{
    public GameObject _thisImage;
    public GameObject _priceText;
    public ItemData _referenceItem;

    
    public static event SetItem SetThisItem;
    public delegate void SetItem(ItemData item);
        

    public void ItemPressed()
    {
        SetThisItem?.Invoke(_referenceItem);
    }

    



}
