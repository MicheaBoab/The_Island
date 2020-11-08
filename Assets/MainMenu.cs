using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public PlayerController player;
    public void PlayGame()
    {

        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        PlayerData save = new PlayerData(player);
        Debug.Log("Exit button Pressed");
        bool saved = SerializationManager.Save(save);
        Debug.Log("Savestate" + saved);
        Application.Quit();
    }
}
