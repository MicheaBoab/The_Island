using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public float[] position;
    public float[] rotation;

    public bool isCarrying;
    public string carriedObject;
    public PlayerData(PlayerController player)//, PickupOjects carriedObj)
    {
        this.position = new float[3];
        this.position[0] = player.controller.transform.position.x;
        this.position[1] = player.controller.transform.position.y;
        this.position[2] = player.controller.transform.position.z;

        this.rotation = new float[3];
        this.rotation[0] = player.controller.transform.rotation.x;
        this.rotation[1] = player.controller.transform.rotation.y;
        this.rotation[2] = player.controller.transform.rotation.z;

        //this.isCarrying = carriedObj.carrying;
        //GameObject carriedObject;
        //string assetPath = AssetDatabase.GetAssetPath((GameObject)data);
    }
}
