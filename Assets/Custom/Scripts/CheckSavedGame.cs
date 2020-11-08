using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CheckSavedGame : MonoBehaviour
{
    public GameObject resumeButton;
    // Start is called before the first frame update
    void Start()
    {
        string path = Application.persistentDataPath + "/saves/game.save";
        Debug.Log("File Path: " + path);
        Debug.Log("Exists check: " + (File.Exists(path)));
        if (File.Exists(path))
        {
            Debug.Log("Resume Button Enabled!");
            resumeButton.SetActive(true);
        }
        else
        {
            Debug.Log("Resume Button Disabled!");
            resumeButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
