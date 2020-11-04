using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupOjects : MonoBehaviour
{
    Camera cam;
    bool carrying = false;
    GameObject carriedObject;
    public float objectDist = 0.5f;
    public float objectHeight = 0.5f;
    public float objectOffset = 0.5f;
    public GameObject torch;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (carrying)
        {
            Carry(carriedObject);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (carrying)
            {
                Debug.Log("Pressed E while carrying");                
                Object.Destroy(carriedObject);
                carrying = false;
                carriedObject = null;
            }

            else
            {
                PickUp();
            }
        }

    }

    void Carry(GameObject obj)
    {
        Rigidbody objRB = obj.GetComponent<Rigidbody>();
        objRB.isKinematic = true;
        Debug.Log("Transform: " + obj.transform.position);
        obj.transform.position = cam.transform.position + (cam.transform.forward * objectDist) + (cam.transform.right * objectOffset) - (cam.transform.up *objectHeight);
        obj.transform.rotation = Quaternion.Euler(-90f, 0, 0);
        obj.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
    }

    void PickUp()
    {

        int x = Screen.width / 2;
        int y = Screen.height / 2;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.distance);
            if(hit.distance < 10f) {
                GameObject obj = Instantiate(torch) as GameObject;
                obj.GetComponent<MeshCollider>().enabled = false;
                //Interactable obj = hit.collider.GetComponent<Interactable>();
                //obj.gameObject.GetComponent<MeshRenderer>().enabled = true;
                if (obj != null)
                {
                    carrying = true;
                    carriedObject = obj;
                    //Debug.Log("Hit " + hit.collider.name);

                }
            }
        }

    }
}


