using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinColorButton : MonoBehaviour
{
    private Button thisButton;
    

    public enum ButtonType
    {
        Skin,
        Hair,
    }
    public ButtonType _thisButtonType;

    public List<Color> _colors;
    public Color thiscolor;
    private int i;


    private void Start()
    {
        i = 0;
        SettingColor();
        
        thisButton = gameObject.GetComponent<Button>();
        //thisButton.onClick.AddListener(this.ChangeColor);
    }

    public void ChangeColor()
    {
        if (i < _colors.Count - 1)
        {
            i++;
            SettingColor();

        }
        if (i == _colors.Count - 1)
        {
            i = 0;
            SettingColor();
        }
    }
    private void SettingColor()
    {
        thiscolor = _colors[i];
        gameObject.GetComponent<Image>().color = thiscolor;
        switch (_thisButtonType)
        {
            case ButtonType.Skin:
                ComponentHandler._thisHandler._config._skinColor = thiscolor;
                ComponentHandler._thisHandler._body.GetComponent<SpriteRenderer>().color = thiscolor;
                break;
            case ButtonType.Hair:
                
                ComponentHandler._thisHandler._config._hairColor = thiscolor;
                if (ComponentHandler._thisHandler._config._wearingHead == null)
                    ComponentHandler._thisHandler._head.GetComponent<SpriteRenderer>().color = thiscolor;
                break;

        }
        
    }
}
