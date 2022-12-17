using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EquippedImage : MonoBehaviour
{
    private Image thisImage;
    public ItemData.ItemTypes _thisType;

    public static event Action TakeOffHat;
    public ItemData _itemEquipped;
    

    private void Awake()
    {
        thisImage = gameObject.GetComponent<Image>();
        
        
        
    }
    private void OnDisable()
    {
        ComponentHandler.ClothesUpdate -= ImageSwap;
        InventoryItemScript.WearThis -= ClothesSwap;
    }
    private void OnEnable()
    {
        ComponentHandler.ClothesUpdate += ImageSwap;
        InventoryItemScript.WearThis += ClothesSwap;
        ImageSwap(ComponentHandler._thisHandler._config._equippedItems);
    }

    public void ClothesSwap(ItemData data)
    {
        if (data._itemType == _thisType)
        if (_thisType == ItemData.ItemTypes.Hat && ComponentHandler._thisHandler._config._wearingHead == null)
            {
                ComponentHandler._thisHandler._config._wearingHead = data;
                ComponentHandler._thisHandler.ChangeClothes();
            }
        else
            {
                switch (_thisType)
                {
                    case ItemData.ItemTypes.Hat:
                        Inventory._thisInventory.AddItem(ComponentHandler._thisHandler._config._wearingHead);
                        ComponentHandler._thisHandler._config._wearingHead = data;
                        ComponentHandler._thisHandler.ChangeClothes();
                        break;
                    case ItemData.ItemTypes.Body:
                        Inventory._thisInventory.AddItem(ComponentHandler._thisHandler._config._wearingBody);
                        ComponentHandler._thisHandler._config._wearingBody = data;
                        ComponentHandler._thisHandler.ChangeClothes();
                        break;
                    case ItemData.ItemTypes.Legs:
                        Inventory._thisInventory.AddItem(ComponentHandler._thisHandler._config._wearingLegs);
                        ComponentHandler._thisHandler._config._wearingLegs = data;
                        ComponentHandler._thisHandler.ChangeClothes();
                        break;
                    case ItemData.ItemTypes.Shoes:
                        Inventory._thisInventory.AddItem(ComponentHandler._thisHandler._config._wearingShoes);
                        ComponentHandler._thisHandler._config._wearingShoes = data;
                        ComponentHandler._thisHandler.ChangeClothes();
                        break;
                }
            }
    }
    public void ImageSwap(ItemData[] equippedItems)
    {
        foreach (ItemData item in equippedItems)
        {
            if (item != null)
            {
                if (item._itemType == _thisType)
                {
                    thisImage.sprite = item._icon;
                }
            }
            else thisImage.sprite = ComponentHandler._thisHandler._config._availableHairStyles._currentIcon;


        }
        
    }

    
    
    public void TakingHatOff()
    {
        TakeOffHat?.Invoke();
        
        thisImage.sprite = ComponentHandler._thisHandler._config._availableHairStyles._currentIcon;
    }

}
