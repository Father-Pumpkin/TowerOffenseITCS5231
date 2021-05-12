using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles movement
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform headHeightStanding;
    public Transform headHeightCrouching;
    public Camera cam;
    private float startHeight;
    private float crouchHeight;

    [Header("Gravity")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool crouching = false;
    bool shouldStand = true;
    Vector3 velocity;
    bool isGrounded;

    private void Start()
    {
        startHeight = this.GetComponentInParent<CharacterController>().height;
        crouchHeight = startHeight / 2;
    }
    // Update is called once per frame
    //Based on movement by Brackeys
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouching = true;
            shouldStand = false;
            cam.transform.position = headHeightCrouching.position;
            this.GetComponentInParent<CharacterController>().height = crouchHeight;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) )
        {
            shouldStand = true;
        }
        if(shouldStand && !Physics.CheckSphere(headHeightStanding.position, .2f, groundMask))
        {
            crouching = false;
            cam.transform.position = headHeightStanding.position;
            this.GetComponentInParent<CharacterController>().height = startHeight;
        }
        if (crouching)
        {
            speed = 3 + .5f * PlayerPrefs.GetInt("Sneak", 0);
            speed = Mathf.Clamp(speed, 0f, 6f);
        }
        else
        {
            speed = 6;
        }
        //check a circle around groundCheck with radius groundDistance Checking against things in groundMask
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // gravity
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        
    }
}
