using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    [System.Serializable]
    public class Movesettings
    {
        public float forwardVel = 12;
        public float rotateVel = 100;
        public float upVel = 25;
        public float downVel = 25;

    }

    public class PhysSettings
    {

    }

    public class InputSettings
    {
        public float inputDelay = 0.1f;
        public string FORWARD_AXIS = "Vertical";
        public string TURN_AXIS = "Horizontal";
        public string UP_DOWN_AXIS = "Up and Down";
        //public string DOWNAXIS = "Down";

    }


    //reference the classes
    public Movesettings moveSettings = new Movesettings();
    public PhysSettings physSettings = new PhysSettings();
    public InputSettings inputSettings = new InputSettings();


    Vector3 velocity = Vector3.zero;
    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput, turnInput, upDownInput;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    void Start()
    {
        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
        {
            rBody = GetComponent<Rigidbody>();
        }

        else
        {
            Debug.LogError("The character needs a rigid body");
        }

        forwardInput = turnInput = upDownInput = 0;

    }

    void GetInput()
    {
        forwardInput = Input.GetAxis(inputSettings.FORWARD_AXIS); //interpolated
        turnInput = Input.GetAxis(inputSettings.TURN_AXIS); //interpolated
        upDownInput = Input.GetAxis(inputSettings.UP_DOWN_AXIS); //interpolated

    }

    void Update()
    {
        GetInput();
        Turn();

    }

    void FixedUpdate()
    {
        Move();
        UpandDown();

        //move in the transforms forward direction and pass in the velocity this way
        rBody.velocity = transform.TransformDirection(velocity);
    }

    void Move()
    {
        if(Mathf.Abs(forwardInput) > inputSettings.inputDelay)
        {
            //move
            // rBody.velocity = transform.forward * forwardInput * moveSettings.forwardVel;
            velocity.z = moveSettings.forwardVel * forwardInput;
        }
        else
        {
            //zero velocity
            //  rBody.velocity = Vector3.zero;
            velocity.z = 0;
        }
    }

    void Turn()
    {
        if (Mathf.Abs(turnInput) > inputSettings.inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis(moveSettings.rotateVel * turnInput * Time.deltaTime, Vector3.up);
        }
        transform.rotation = targetRotation;
    }

    void UpandDown()
    {
        if (Mathf.Abs(upDownInput) > inputSettings.inputDelay)
        {
            //jump
            velocity.y = moveSettings.upVel * upDownInput;
        }
        else if (upDownInput == 0)
        {
            //zero velocity
            velocity.y = 0;
        }
    }
}
