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
        string path = Application.persistentDataPath + "saves/game.save";
        Debug.Log(Application.persistentDataPath);
        if (File.Exists(path))
        {
            resumeButton.SetActive(true);
        }
        else
        {
            resumeButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
