using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyPanel : MonoBehaviour
{
    public static MoneyPanel _moneyPanel;
    private float currentMoney;
    public TMP_Text _thisText;

    private void Awake()
    {
        _moneyPanel = this;
    }

    private void Start()
    {
        UpdateMoney();
    }
   

    public void UpdateMoney()
    {
        currentMoney = ComponentHandler._thisHandler._currentCash; 
        _thisText.text = $"{currentMoney}$";
    }
}
