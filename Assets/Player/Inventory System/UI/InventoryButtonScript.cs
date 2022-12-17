using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class InventoryButtonScript : MonoBehaviour
{
    public ItemData.ItemTypes _type;
    
    
    public static event ButtonTypePressed ButtonPressed;
    public delegate void ButtonTypePressed(ItemData.ItemTypes _thisType);

    
    public void Clicked()
    {
        ButtonPressed?.Invoke(_type);
    }


}
