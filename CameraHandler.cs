using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    // Mouse tracking

    float mouseX;
    float mouseY;
    
    // Player transform
    private Transform myTransform;

    public Transform playerFollowPoint;

    // Camera lock-on paramaters
    public Transform targetTransform;
    private float rotationPower = 20f;

    // Virtual Cameras
    public GameObject thirdPersonFreeAim;
    public GameObject thirdPersonReticuleAim;

    // Camera transform
    // public Transform cameraPivotTransform;
    // private Vector3 cameraTransformPosition;
    // private LayerMask ignoreLayers;

    // public static CameraHandler singleton;

    // public float lookSpeed = 0.1f;
    // public float followSpeed = 0.1f;
    // public float pivotSpeed = 0.03f;

    // private float defaultPosition;
    // private float lookAngle;
    // private float pivotAngle;

    // public float minimumPivot = 35f;
    // public float maximumPivot = -35f;

private void Start()
{
    myTransform = transform;

    mouseX = Input.GetAxis("Mouse X");
    mouseY = Input.GetAxis("Mouse Y");
}

void Update()
{
    // Debug.Log(cameraTransform.localPosition.z);

    mouseX = Input.GetAxis("Mouse X");
    mouseY = Input.GetAxis("Mouse Y");

    RotatePlayerFollowPoint();
}

private void RotatePlayerFollowPoint()
{
    //Debug.Log(playerFollowPoint.transform.rotation);

    playerFollowPoint.transform.rotation *= Quaternion.AngleAxis(mouseX * rotationPower, Vector3.up);
    playerFollowPoint.transform.rotation *= Quaternion.AngleAxis(mouseY * rotationPower, Vector3.right);

//    Debug.Log(playerFollowPoint.transform.rotation);

    Vector3 angles = playerFollowPoint.transform.localEulerAngles;
    angles.z = 0;

    float angle = playerFollowPoint.transform.localEulerAngles.x;

    if (angle > 180 && angle < 340)
    {
        angles.x = 340;
    }
    else if (angle < 180 && angle > 40)
    {
        angles.x = 40;
    }

    playerFollowPoint.transform.localEulerAngles = angles;

    if (Input.GetKeyDown(KeyCode.R))
    {
        Debug.Log("Engage crosshair firing");
    }
}

}