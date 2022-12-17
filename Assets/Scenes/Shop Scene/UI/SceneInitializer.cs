using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{

    public GameObject[] _uiWindows;
    

    
    
    private void Start()
    {
        foreach (GameObject window in _uiWindows)
        {
            window.SetActive(false);
        }
        
        if (ComponentHandler._thisHandler != null)
        {
            ComponentHandler._thisHandler.transform.GetComponent<MovingScript>().DirectionReset();
        }


    }
}
