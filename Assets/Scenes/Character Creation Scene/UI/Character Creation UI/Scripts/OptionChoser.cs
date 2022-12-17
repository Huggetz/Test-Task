using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionChoser : MonoBehaviour
{
    public ClothesOptions _optionsConfig;
    private Image _thisImage;

    private void Awake()
    {
        if (_optionsConfig._currentOption == null && _optionsConfig._thisListType != ItemData.ItemTypes.Hat)
        {
            _optionsConfig._currentStyle = 0;
            _optionsConfig.HairResetter();
            _optionsConfig.SettingStyle();
            
        }
        
            _thisImage = transform.GetComponent<Image>();
        //_thisImage.transform.localScale *= 10;
        SwapImage();
    }

    public void SwapImage()
    {
        _thisImage.sprite = _optionsConfig._currentIcon;

    }
}
