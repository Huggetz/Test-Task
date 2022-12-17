using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Player/ HairStyle List")]

public class HairStyles : ScriptableObject
{
    public AnimatorOverrideController _currentHairstyleAnimator;
    public Sprite _currentIcon;

    [HideInInspector] public int _currentStyle;
    public List<AnimatorOverrideController> _hairstyleAnimators;
    public List<Sprite> _hairstyleIcons;

    public void ScrollLeft()
    {
        if (_currentStyle > 0)
        {
            _currentStyle--;
            SettingStyle();
        }
        else
        {
            _currentStyle = _hairstyleAnimators.Count - 1;
            SettingStyle();
        }

    }

    public void ScrollRight()
    {
        {
            if (_currentStyle < _hairstyleAnimators.Count - 1)
            {
                _currentStyle++;
                SettingStyle();
            }
            else
            {
                _currentStyle = 0;
                SettingStyle();
            }

        }
    }

    public void SettingStyle()
    {
        _currentHairstyleAnimator = _hairstyleAnimators[_currentStyle];
        _currentIcon = _hairstyleIcons[_currentStyle];
    }
}
