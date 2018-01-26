using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public float lookSmooth = 0.09f;
    public Vector3 offsetfromTarget = new Vector3(0, -6, -8);

    //value to look down on target
    public float xTilt = 10;

    //where the camera is moving to
    Vector3 destination = Vector3.zero;

    //get character controller to get rotational values for the player
    CharacterController charController;

    float rotateVel = 0;

    void Start()
    {
        SetCameraTarget(target);
    }

    void SetCameraTarget(Transform t)
    {
        target = t;

        if(target != null)
        {
            if(target.GetComponent<CharacterController>())
            {
                charController = target.GetComponent<CharacterController>();
            }
            else
            {
                Debug.LogError("Camera target needs a character controller");
            }
        }

        else
        {
            Debug.LogError("Camera needs a target");
        }
    }

    void LateUpdate()
    {
        //moving and roatating
        MoveToTarget();
        LookAtTarget();
    }

    void MoveToTarget()
    {
        //moving the camera behind the target
        destination = charController.TargetRotation * offsetfromTarget;
        destination += target.position = destination;
    }

    void LookAtTarget()
    {
        //smoother lerp
        float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerYAngle, 0);
    }
}
