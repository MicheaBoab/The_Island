using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public PlayerController player;
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
    }

    public void LoadMenu()
    {
        bool saved = Save();
        Debug.Log("Savestate" + saved);
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        bool saved = Save();
        Debug.Log("Savestate" + saved);

        Application.Quit();
    }

    bool Save()
    {
        SaveData.current.playerPosition = player.controller.transform.position;
        SaveData.current.playerRotation = player.controller.transform.rotation;

        return SerializationManager.Save(SaveData.current);
    }

}
