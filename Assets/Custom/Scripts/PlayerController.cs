using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float moveSpeed = 5f;
    public float jumpHeight = 10f;
    public float gravity = Physics.gravity.y;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;


    Vector3 velocity;


    AudioSource footstepSound;

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

        Debug.Log("Velocity at start: " + controller.velocity.magnitude);
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

        PlayFootstepSound();
        Debug.Log("Velocity at end: " + controller.velocity.magnitude);
    }

    void PlayFootstepSound()
    {
        /*if (!controller.isGrounded)
            return;
        */

        if (controller.velocity.magnitude > 0)
        {
            //Debug.Log("Velocity is"+ controller.velocity.magnitude);
            accumulatedDistance += (velocity * Time.deltaTime).magnitude;
            if(accumulatedDistance > stepDistance)
            {
                footstepSound.volume = Random.Range(minVolume, maxVolume);
                footstepSound.clip = footstepClip[Random.Range(0, footstepClip.Length)];
                footstepSound.Play();

                accumulatedDistance = 0f;
            }
        }else
        {
            //Debug.Log("Velocity is 0");
            accumulatedDistance = 0f;
        }
    }
}