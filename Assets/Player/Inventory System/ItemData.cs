using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Items/Clothing")]
public class ItemData : ScriptableObject
{
    public string _name;
    public float _price;
    public AnimatorOverrideController _animator;
    public Sprite _icon;
    public ItemTypes _itemType;

    public enum ItemTypes
    {
        Hat,
        Body,
        Legs,
        Shoes,
    }
}
