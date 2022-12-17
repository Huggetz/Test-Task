using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwapper : MonoBehaviour
{
    public List<GameObject> _panels;
    public static PanelSwapper _thisSwapper;
    

    private void Awake()
    {
        _thisSwapper = this;
        RectTransform[] panels = GetComponentsInChildren<RectTransform>();
        foreach (RectTransform panel in panels)
        {
            if (panel.gameObject.tag == ("Panel"))
                _panels.Add(panel.gameObject);
        }
    }
    private void OnEnable()
    {
        InventoryButtonScript.ButtonPressed += SwapPanel;
    }
    private void OnDisable()
    {
        InventoryButtonScript.ButtonPressed -= SwapPanel;
    }

    public void SwapPanel(ItemData.ItemTypes _type)
    {
        
        foreach (GameObject panel in _panels)
        {
            if (panel.GetComponent<PanelType>()._thisType == _type)
                panel.SetActive(true);
            else panel.SetActive(false);
        } 
    }
}
