using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    public CharacterController controller;

    public float moveSpeed = 15f;
    public float jumpHeight = 10f;
    public float gravity = Physics.gravity.y;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    bool carrying = false;
    GameObject carriedObject;
    public float objectDist = 2f;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (carrying)
        {
            Carry(carriedObject);
        } else
        {
            PickUp();
        }
       

    }

    void Carry(GameObject obj)
    {
        Rigidbody objRB = obj.GetComponent<Rigidbody>();
        objRB.isKinematic = true;

        obj.transform.position = cam.transform.position + cam.transform.forward * objectDist;
    }

    void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = cam.ScreenPointToRay(new Vector3(x, y));

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Interactable obj = hit.collider.GetComponent<Interactable>();
                if (obj != null)
                {
                    carrying = true;
                    carriedObject = obj.gameObject;
                    Debug.Log("Hit " + hit.collider.name);

                }
            }
        }
    }
}
