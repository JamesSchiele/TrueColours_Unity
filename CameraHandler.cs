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

    // Camera transform
    public Transform cameraTransform;
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

// public void FollowTarget(float delta)
// {
//     Vector3 targetPosition = Vector3.Lerp(myTransform.position, targetTransform.position, delta / followSpeed);
//     myTransform.position = targetPosition;
// }

// public void HandleCameraRotation(float delta, float mouseXInput, float mouseYInput)
// {
//     lookAngle += (mouseXInput * lookSpeed) / delta;
//     pivotAngle -= (mouseYInput * pivotSpeed) / delta;
//     pivotAngle = Mathf.Clamp(pivotAngle, minimumPivot, maximumPivot); // Clamp camera to be within specific boundaries

//     Vector3 rotation = Vector3.zero;
//     rotation.y = lookAngle;
//     Quaternion targetRotation = Quaternion.Euler(rotation);
//     myTransform.rotation = targetRotation;

//     rotation = Vector3.zero;
//     rotation.x = pivotAngle;

//     targetRotation = Quaternion.Euler(rotation);
//     cameraPivotTransform.localRotation = targetRotation;
// }

void Update()
{
    // Debug.Log(cameraTransform.localPosition.z);

    mouseX = Input.GetAxis("Mouse X");
    mouseY = Input.GetAxis("Mouse Y");

    // Vector3 target = targetTransform.position;

    // Quaternion newRotation = Quaternion.LookRotation(myTransform.position - targetTransform.position, Vector3.forward);
    // newRotation.x = 0.0f;
    // newRotation.y = 0.0f;
    // cameraTransform.rotation = Quaternion.Slerp(myTransform.rotation, newRotation, Time.deltaTime * 8);

    // cameraTransform.LookAt(target);

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
}

}