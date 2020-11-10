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
        if (SaveData.current.playerPosition == new Vector3(0, 0, 0))
        {
            player.LoadData(new Vector3(964.187744f, 29.2077141f, 214.325027f), new Quaternion(0.0230048969f, 0.782347977f, -0.0289473943f, 0.621743143f));

        }
        else
        {
            player.LoadData(SaveData.current.playerPosition, SaveData.current.playerRotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
