using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ComponentHandler : MonoBehaviour
{
    
    public string _clothesTag, _bodyTag;
    [HideInInspector] public static ComponentHandler _thisHandler;
    public PlayerConfiguration _config;
    public GameObject _body;
    public GameObject _head;
    public GameObject _chest;
    public GameObject _legs;
    public GameObject _feet;
    public float _currentCash;
    

    public static event Updater ClothesUpdate;
    public delegate void Updater(ItemData[] items);
    public static event AddToInventory AddThis;
    public delegate void AddToInventory(ItemData itemData);

   

    private void Awake()
    {
        
        _thisHandler = this;
        _body = GameObject.FindGameObjectWithTag(_bodyTag);
        _body.GetComponent<SpriteRenderer>().color = _config._skinColor;
        ChangeClothes();

    }
    
    private void OnDisable()
    {
        EquippedImage.TakeOffHat -= ChangeHat;
    }
    private void OnEnable()
    {
        EquippedImage.TakeOffHat += ChangeHat;
        
    }

    public void ChangeHat()
    {
        AddThis?.Invoke(_config._wearingHead);
        _config._wearingHead = null;
        ChangeClothes();

    }
    
    
    public void ChangeClothes()
    {
        if (_config._wearingHead != null)
        _head.GetComponent<Animator>().runtimeAnimatorController = _config._wearingHead._animator;

        if (_config._wearingHead == null)
        {
            _head.GetComponent<SpriteRenderer>().color = _config._hairColor;
            _head.GetComponent<Animator>().runtimeAnimatorController = _config._availableHairStyles._currentHairstyleAnimator;
        }
        else _head.GetComponent<SpriteRenderer>().color = Color.white;

        

        _chest.GetComponent<Animator>().runtimeAnimatorController = _config._wearingBody._animator;
        _legs.GetComponent<Animator>().runtimeAnimatorController = _config._wearingLegs._animator;
        _feet.GetComponent<Animator>().runtimeAnimatorController = _config._wearingShoes._animator;
        _config._equippedItems = new ItemData[] { _config._wearingHead, _config._wearingBody, _config._wearingLegs, _config._wearingShoes };
        ClothesUpdate?.Invoke(_config._equippedItems);
    }
}
 