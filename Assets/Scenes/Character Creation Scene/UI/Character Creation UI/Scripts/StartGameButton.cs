using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartGameButton : MonoBehaviour
{
    public GameObject _namePanel;

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        
    }
    public void SaveTheName()
    {
        TMP_InputField nameField = _namePanel.GetComponent<TMP_InputField>();
        ComponentHandler._thisHandler._config._characterName = nameField.text;
    }

    
}
