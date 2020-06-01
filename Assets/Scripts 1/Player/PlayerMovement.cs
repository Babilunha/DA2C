using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //camera of the player to perform rotation
    [SerializeField]
    private Camera cam = null;
    //point from which the distance to the ground is calculated
    [SerializeField]
    private Transform groundCheck = null;
    public LayerMask groundMask;
    //levitation
    [SerializeField]
    private float levitationForce = 95f;
    public RaycastHit levitationHit;

    //limit for the camera up and down movement (value in degrees) 
    [SerializeField]
    private float cameraRotationLimit = 80f;
    //speed of the player
    [SerializeField]
    private float defaultSpeed = 5f;
    private float currentSpeed = 0f;
    //sensetivity of the camera
    [SerializeField]
    private float lookSensitivity = 3f;
    //power of the jet pack of the player
    [SerializeField]
    private float jetPower = 500f;


    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;


    private float rotationCameraX = 0f;
    private float currentCameraRotationX = 0f;

    //rigidbody of the player to perform physics on
    private new Rigidbody rigidbody;

    public Joystick joystick; 



    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }



    private void Update()
    {
        if (!MyGameManager.gameIsPaused)
        {
            Levitate();
            Fly();

            //Calculate movement velocity as a 3D vector
            //float xMovement = Input.GetAxisRaw("Horizontal");
            //float zMovkement = Input.GetAxisRaw("Vertical");
            float xMovement = joystick.Horizontal;
            float zMovement = joystick.Vertical;


            Vector3 moveHorizontal = transform.right * xMovement; //1 0 0 
            Vector3 moveVertical = transform.forward * zMovement; //0 0 1

            //final mocemnet vector
            velocity = (moveHorizontal + moveVertical).normalized * currentSpeed;

            //calculate rotation as a 3d vector (left and right)
            float yRotation = Input.GetAxisRaw("Mouse X");

            rotation = new Vector3(0f, yRotation, 0f) * lookSensitivity;


            //calculate camera as a 3d vector (left and right)
            float xRotation = Input.GetAxisRaw("Mouse Y");

            rotationCameraX = xRotation * lookSensitivity;
        }

        

    }


    void FixedUpdate()
    {
        if (!MyGameManager.gameIsPaused)
        {
            PerformMovement();
            PerformRotation();


            SpeedBoost();
        }

    }

    private void SpeedBoost()
    {


        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = defaultSpeed * 2f;
        }
        else
        {
            currentSpeed = defaultSpeed;
        }

    }

    private void Levitate()
    {
        
        if (Physics.Raycast(groundCheck.transform.position, groundCheck.transform.forward, out levitationHit, groundMask))
        {
            //Debug.Log("Distance is " + levitationHit.distance);
            rigidbody.AddForce((Vector3.up * levitationForce * rigidbody.mass) / levitationHit.distance, ForceMode.Force);

        }


    }

    private void Fly()
    {
        if (Input.GetButton("Jump"))
        {
            rigidbody.AddForce(Vector3.up * jetPower * Time.deltaTime, ForceMode.Acceleration);
        }


    }



    private void PerformRotation()
    {
        rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            //set our rotation and clamp it 
            currentCameraRotationX -= rotationCameraX;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

            //apply rotation to the transform of the camera 
            cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
        }

    }

    private void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
        }



    }
}
