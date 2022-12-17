using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public Dictionary<ItemData, Item> _inventory;
    public static Inventory _thisInventory;
    public Dictionary<List<ItemData>, ItemData.ItemTypes> _inventoryTabs;
    public List<ItemData> _inventoryHats;
    public List<ItemData> _inventoryBody;
    public List<ItemData> _inventoryLegs;
    public List<ItemData> _inventoryShoes;
    public GameObject _inventoryItemPanel;
    public GameObject[] _panels;
    
    
    


    private void OnEnable()
    {
        ComponentHandler.AddThis += AddItem;
    }
    private void OnDisable()
    {
        ComponentHandler.AddThis -= AddItem;
    }


    private void Awake()
    {
        _inventoryTabs = new Dictionary<List<ItemData>, ItemData.ItemTypes>();
        _inventoryTabs.Add(_inventoryHats, ItemData.ItemTypes.Hat);
        _inventoryTabs.Add(_inventoryBody, ItemData.ItemTypes.Body);
        _inventoryTabs.Add(_inventoryLegs, ItemData.ItemTypes.Legs);
        _inventoryTabs.Add(_inventoryShoes, ItemData.ItemTypes.Shoes);

        _thisInventory = this;
        _inventory = new Dictionary<ItemData, Item>();

        
    }
    
    public void AddItem(ItemData data)
    {
        if (!_inventory.TryGetValue((data), out Item thisitem))
        {
            Item newItem = new Item(data);
            _inventory.Add(data, newItem);
            InventorySorterOnAdd(newItem);
        }
        else
        {
            // Debug.Log($"{thisitem} already exists in Your inventory");
        }
    }
    public void RemoveItem(ItemData data)
    {
        if (_inventory.TryGetValue((data), out Item thisitem))
        {
            InventorySorterOnRemove(data);
            _inventory.Remove(data);
            
            
        }
        else
        {
            // Debug.Log($"{thisitem} was not in your inventory");
        }
    }

    public void InventorySorterOnAdd(Item thisitem)
    {
        foreach (KeyValuePair<ItemData, Item> item in _inventory)
        {
            if (thisitem == item.Value)
            {
                foreach (KeyValuePair<List<ItemData>, ItemData.ItemTypes> tab in _inventoryTabs)
                    if (tab.Value == thisitem._itemData._itemType)
                    {
                        //Debug.Log("Can Add");
                        
                        if (!tab.Key.Contains(thisitem._itemData))
                        {
                            tab.Key.Add(thisitem._itemData);
                            foreach (GameObject panel in PanelSwapper._thisSwapper._panels)
                            {
                                if (panel.GetComponent<PanelType>()._thisType == thisitem._itemData._itemType)
                                {
                                    GameObject newPanel = Instantiate(_inventoryItemPanel, panel.transform.Find("Items").transform, false);
                                    newPanel.GetComponentInChildren<InventoryItemScript>()._thisItem = thisitem._itemData;
                                    newPanel.GetComponentInChildren<InventoryItemScript>().SetImage();
                                }
                            }
                        }
                        

                    }
            }
        
            
           
        }
    }

    public void InventorySorterOnRemove(ItemData thisitem)
    {
        foreach (KeyValuePair<ItemData, Item> item in _inventory)
            if (thisitem == item.Key)
            {
                
                foreach (KeyValuePair<List<ItemData>, ItemData.ItemTypes> tab in _inventoryTabs)
                    if (tab.Value == thisitem._itemType)
                    {
                        foreach (GameObject panel in _panels)
                        {
                            Transform[] childtransforms = panel.transform.GetComponentsInChildren<Transform>();
                            foreach (Transform trans in childtransforms)
                            {
                                trans.TryGetComponent<InventoryItemScript>(out InventoryItemScript component);
                                
                                if (component != null && component._thisItem == thisitem)
                                {
                                    Debug.Log($"Removed {component._thisItem}");
                                    Destroy(component.transform.parent.gameObject);

                                }
                                
                            }
                        }
                        
                        //DestroyThis?.Invoke(thisitem);
                        tab.Key.Remove(thisitem);

                        
                    }
            }
        
                
    }
}
