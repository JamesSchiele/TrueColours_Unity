using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform playerBody;
    public Transform playerFiringPoint;

    CameraHandler cameraHander;

    public Transform cam; 


    public float mouseX;
    public float mouseY;
    public float speed;
    public float walkSpeed = 6f;
    public float runSpeed = 25f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public bool RotateAroundPlayer = true;
    public float RotationSpeed = 5f;

   void Start()
   {

   }

    // private void FixedUpdate()
    // {
    //     float delta = 0.01f;

    //     if (cameraHander != null)
    //     {
    //         cameraHander.FollowTarget(delta);
    //         cameraHander.HandleCameraRotation(delta, mouseX, mouseY);
    //     }
    // }

    private void Update()
    {
        // Player-based movement

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // Normalise means holding two keys wont make you go abnormally fast

        if(direction.magnitude >= 0.1f)
        {          
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; // Find direction of velocity from two co-ordinates, translate from radian to degrees
            
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            //transform.rotation = Quaternion.Euler(0f, angle, 0f); 

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            playerBody.rotation = Quaternion.LookRotation(moveDir);
            playerFiringPoint.rotation = Quaternion.LookRotation(moveDir);

            if (Input.GetKey("left shift"))
            {
                speed = runSpeed;
            }
            else
            { 
                speed = walkSpeed;
            };

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

    }

}
