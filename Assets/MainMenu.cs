using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void NewGame()
    {

        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        SaveData.current.playerPosition = new Vector3(954,24.1597652f,274);
        SaveData.current.playerRotation = new Quaternion(0.0230048969f,0.782347977f,-0.0289473943f,0.621743143f);
    }

    public void ResumeGame()
    {
        string path = Application.persistentDataPath + "/saves/game.save";

        Debug.Log("Resume Button");
        SaveData loadedData = (SaveData)SerializationManager.Load(path);
        SaveData.current.playerPosition = loadedData.playerPosition;
        SaveData.current.playerRotation = loadedData.playerRotation;
        Debug.Log("Loaded Position: " + loadedData.playerPosition);


        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void QuitGame()
    {

        Application.Quit();
    }
}
