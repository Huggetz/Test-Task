using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenderButtonScript : MonoBehaviour
{
    private Button thisButton;

    public List<Color> _colors;
    [HideInInspector] public Color thiscolor;
    

    private void Start()
    {
        
        if (ComponentHandler._thisHandler._config._playerGender == PlayerConfiguration.Gender.Female) thiscolor = _colors[1];
        else thiscolor = _colors[0];
        gameObject.GetComponent<Image>().color = thiscolor;
        thisButton = gameObject.GetComponent<Button>();
        thisButton.onClick.AddListener(ChangeGender);
    }

    private void ChangeGender()
    {
        if (thiscolor == _colors[0])
        {
            thiscolor = _colors[1];
            ComponentHandler._thisHandler._config._playerGender = PlayerConfiguration.Gender.Female;
        }
        else
        {
            thiscolor = _colors[0];
            ComponentHandler._thisHandler._config._playerGender = PlayerConfiguration.Gender.Male;
        }
        gameObject.GetComponent<Image>().color = thiscolor;
        

    }


}
