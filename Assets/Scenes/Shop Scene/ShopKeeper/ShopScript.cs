using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopScript : MonoBehaviour
{
    public static ShopScript _thisShop;
    public DataBase _allItems;
    public GameObject[] _panels;
    public GameObject _sellingSlot;

    
    

    private void Awake()
    {
        _thisShop = this;
        foreach(ItemData item in _allItems._database)
        {
            foreach (GameObject panel in _panels)
            {
                if (panel.GetComponent<PanelType>()._thisType == item._itemType)
                {
                    GameObject newPanel = Instantiate(_sellingSlot, panel.transform, false);
                    newPanel.GetComponent<ItemsForSale>()._referenceItem = item;
                    newPanel.GetComponent<ItemsForSale>()._thisImage.GetComponent<Image>().sprite = item._icon;
                    newPanel.GetComponent<ItemsForSale>()._priceText.GetComponent<TMP_Text>().text = $"{item._price}$";
                    
                }
            }
        }
    }

    
}
