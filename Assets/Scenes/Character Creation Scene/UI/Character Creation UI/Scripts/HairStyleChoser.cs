using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HairStyleChoser : MonoBehaviour
{
    public HairStyles _hairstyleList;
    private Image _thisImage;
    private void Awake()
    {
        if (_hairstyleList._currentIcon == null || _hairstyleList._currentHairstyleAnimator == null)
        {
            _hairstyleList._currentStyle = 0;
            _hairstyleList.SettingStyle();
        }
        _thisImage = transform.GetComponent<Image>();
        //_thisImage.transform.localScale *= 10;
        SwapImage();
    }

    public void SwapImage()
    {
        _thisImage.sprite = _hairstyleList._currentIcon;

    }

}
