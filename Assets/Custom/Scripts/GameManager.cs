using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public static GameManager instance;

    public PlayerController player;
    // Start is called before the first frame update
    void Awake()
    {
        //if (instance == null) instance = this;
        //else if (instance != this) Destroy(gameObject);
        //DontDestroyOnLoad(gameObject);
        Debug.Log("Setting transform in GM");
        Debug.Log(SaveData.current.playerPosition);
        player.LoadData(SaveData.current.playerPosition, SaveData.current.playerRotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
