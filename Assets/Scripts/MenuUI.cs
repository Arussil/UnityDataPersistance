using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUI : MonoBehaviour
{

    public TMP_InputField playerName;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void StartNew()
    {
        DataManager.Instance.playerName = playerName.text;
        SceneManager.LoadScene(1); 
    }
}
