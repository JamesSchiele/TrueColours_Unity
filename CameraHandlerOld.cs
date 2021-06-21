// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;


// public class CameraHandler : MonoBehaviour
// {
//     public Transform cameraTransform;

//     public Transform nearestLockOnTarget;

//     ThirdPersonMovement thirdPersonMovement;

//     public Transform PlayerTransform;

//     private Vector3 _cameraOffset;

//     public Transform cameraPivotTransform;

//     public Transform currentLockOnTarget;

//     public bool lockOnFlag;
//     public bool lockOnInput;

//     public bool RotateAroundPlayer = true;
//     public float RotationSpeed = 5f;

//     public float maximumLockOnDistance = 30f;
//     List<Enemy> availableTargets = new List<Enemy>();

//     private void Awake()
//     {
//         thirdPersonMovement = FindObjectOfType<ThirdPersonMovement>();
//         _cameraOffset = transform.position - PlayerTransform.position;

//     }

//     void LateUpdate()
//     {
//         if (RotateAroundPlayer)
//         {
//             Quaternion camTurnAngel = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
//             _cameraOffset = camTurnAngel * _cameraOffset;
//         }
        
//         Vector3 newPos = PlayerTransform.position + _cameraOffset;

//         transform.position = Vector3.Slerp(transform.position, newPos, RotationSpeed);

//         if (RotateAroundPlayer)
//         {
//             transform.LookAt(PlayerTransform);
//         }
        
//         HandleLockOnInput();

//     }

//     public void HandleLockOn()
//     {
//         float shortestDistance = Mathf.Infinity;

//         Collider[] colliders = Physics.OverlapSphere(transform.position, 100);

//         for(int i = 0; i <= colliders.Length; i++)
//         {
//             Enemy enemy = colliders[i].GetComponent<Enemy>();

//             Debug.Log(i);

//             if(enemy != null)
//             {
//                 Vector3 lockTargetDirection = enemy.transform.position - this.transform.position;
//                 float distanceFromTarget = Vector3.Distance(this.transform.position, enemy.transform.position);
//                 float viewableAngle = Vector3.Angle(lockTargetDirection, cameraTransform.forward);

//                 if (enemy.transform.root != this.transform.root
//                     && viewableAngle > -50f && viewableAngle < 50f 
//                     && distanceFromTarget <= maximumLockOnDistance)
//                     {
//                         availableTargets.Add(enemy);

//                         Debug.Log(availableTargets);
//                     }
//             }
//         }

//         for (int k = 0; k < availableTargets.Count; k++)
//         {
//             float distanceFromTarget = Vector3.Distance(this.transform.position, availableTargets[k].transform.position);

//             if(distanceFromTarget < shortestDistance)
//             {
//                 shortestDistance = distanceFromTarget;
//                 nearestLockOnTarget = availableTargets[k].LockOnTransform;
//             }

//         }
//     }
//         private void HandleLockOnInput()
//     {
//         if(lockOnInput && lockOnFlag == false)
//         {
//             lockOnInput = false;
//             lockOnFlag = false;
//             if (this.nearestLockOnTarget != null)
//             {
//                 this.currentLockOnTarget = this.nearestLockOnTarget;
//                 lockOnFlag = true;
//             }

//             this.HandleLockOn();
//         }
//         else if (lockOnInput && lockOnFlag)
//         {
//             lockOnInput = false;
//             lockOnFlag = false;
//             // Clear lock on targets
//         }
//     }

//     private void HandleCameraRotation()
//     {
//         if (lockOnFlag == true && currentLockOnTarget != null)
//         {
//             float veloctiy = 0;

//             Vector3 dir = currentLockOnTarget.position - transform.position;
//             dir.Normalize();
//             dir.y = 0;

//             Quaternion targetRotation = Quaternion.LookRotation(dir);
//             transform.rotation = targetRotation;

//             dir = currentLockOnTarget.position - cameraPivotTransform.position;
//             dir.Normalize();

//             targetRotation = Quaternion.LookRotation(dir);
//             Vector3 eulerAngles = targetRotation.eulerAngles;
//             eulerAngles.y = 0;
//             cameraPivotTransform.localEulerAngles = eulerAngles;
//         }
//     }

//     public void ClearLockOnTargets()
//     {
//         availableTargets.Clear();
//         currentLockOnTarget = null;
//         nearestLockOnTarget = null;
//     }

// }
