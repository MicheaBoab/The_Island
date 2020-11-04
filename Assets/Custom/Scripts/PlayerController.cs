using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Controller")]
    public CharacterController controller;
    public float moveSpeed = 5f;
    public float jumpHeight = 10f;
    public float gravity = Physics.gravity.y;
    private Vector3 jumpVelocity = Vector3.zero;
    public float airSpeed = 2.0f;
    public float airFriction = 0.65f;

    
    AudioSource footstepSound;

    [Header("Sound Settings")]
    [SerializeField]
    AudioClip[] footstepClip;
    public float minVolume, maxVolume;
    float accumulatedDistance;
    public float stepDistance;

    private void Awake()
    {
        footstepSound = GetComponent<AudioSource>();

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("Velocity at start: " + controller.velocity.magnitude);
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //if (isGrounded && velocity.y < 0)
        //{
        //   velocity.y = 0f;
        //}

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Vector3 move = transform.right * x + transform.forward * z;
        Vector3 movement = new Vector3(x, 0, z);
        movement = transform.TransformDirection(movement);

        //controller.Move(move * moveSpeed * Time.deltaTime);
        /*
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        */

        if (controller.isGrounded)
        {
            //Debug.Log("Grounded");
            //controller.slopeLimit = 45.0f;
            movement *= moveSpeed;
            if (Input.GetButton("Jump"))
            {
                jumpVelocity = movement * airFriction;
                jumpVelocity.y = jumpHeight;
                //controller.slopeLimit = 90.0f;
            }
            else
            {
                jumpVelocity = Vector3.zero; //Stop all movement done through jump vector includes x,z movement (air movement) and y movement (jump)
                jumpVelocity.y = -100f; // Apply a strong downward force to ground the player
            }
        } else {
            //Debug.Log("Not-Grounded");
            movement *= airSpeed;
        }

        jumpVelocity.y += gravity * Time.deltaTime;
        movement += jumpVelocity;
        Debug.Log(movement);
        controller.Move(movement * Time.deltaTime);

        /********************************/
        PlayFootstepSound();
        //Debug.Log("Velocity at end: " + controller.velocity.magnitude);
    }


    void PlayFootstepSound()
    {
        if (!controller.isGrounded)
            return;
        

        if (controller.velocity.magnitude > 0)
        {
            //Debug.Log("Velocity is"+ controller.velocity.magnitude);
            accumulatedDistance += (controller.velocity * Time.deltaTime).magnitude;
            Debug.Log(accumulatedDistance);
            if (accumulatedDistance > stepDistance)
            {
                footstepSound.volume = Random.Range(minVolume, maxVolume);
                footstepSound.clip = footstepClip[Random.Range(0, footstepClip.Length)];
                footstepSound.Play();

                accumulatedDistance = 0f;
            }
        }
        else
        {
            //Debug.Log("Velocity is 0");
            accumulatedDistance = 0f;
        }
    }
}