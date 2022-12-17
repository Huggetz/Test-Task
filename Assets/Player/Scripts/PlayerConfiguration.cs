using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Player/Player Configuration")]

public class PlayerConfiguration : ScriptableObject
{

    public string _characterName;
    public Gender _playerGender;
    public Color _skinColor;
    public HairStyles _availableHairStyles;
    public ItemData _wearingHead;
    public ItemData _wearingBody;
    public ItemData _wearingLegs;
    public ItemData _wearingShoes;
    public ItemData[] _equippedItems;



    public Color _hairColor;

    public enum Gender
    {
        Male,
        Female, 
    }
    



}
