using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PreviewPanelScript : MonoBehaviour
{
    public DataBase _dataBase;
    public GameObject _previewImage;
    public GameObject _previewPrice;
    public ItemData _currentPreview;

    private void Awake()
    {
        _currentPreview = _dataBase._database[0];
        ResetPreview();
        ItemsForSale.SetThisItem += SetPreviewItem;
    }

    public void SetPreviewItem(ItemData item)
    {
        _currentPreview = item;
        ResetPreview();
    }

    public void ResetPreview()
    {
        _previewImage.GetComponent<Image>().sprite = _currentPreview._icon;
        _previewPrice.GetComponent<TMP_Text>().text = $"{_currentPreview._price}$";
    }

    public void Buy()
    {
        if (!Inventory._thisInventory._inventory.TryGetValue((_currentPreview), out Item thisItem))
        {
            if (ComponentHandler._thisHandler._currentCash >= _currentPreview._price)
            {
                Inventory._thisInventory.AddItem(_currentPreview);
                ComponentHandler._thisHandler._currentCash -= _currentPreview._price;
            }
        }
        else Debug.Log($"The {_currentPreview} item is already owned.");
        MoneyPanel._moneyPanel.UpdateMoney();
    }
    public void Sell()
    {
        if (Inventory._thisInventory._inventory.TryGetValue((_currentPreview), out Item thisItem))
        {
            Inventory._thisInventory.RemoveItem(_currentPreview);
            ComponentHandler._thisHandler._currentCash += (float)(int)(_currentPreview._price * 0.75f);
            MoneyPanel._moneyPanel.UpdateMoney();
        }
    }
    private void OnEnable()
    {
        ItemsForSale.SetThisItem += SetPreviewItem;
    }
    private void OnDisable()
    {
        ItemsForSale.SetThisItem -= SetPreviewItem;
    }
}
