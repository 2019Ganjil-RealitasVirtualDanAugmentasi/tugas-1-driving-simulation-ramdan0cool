using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleCarControl : MonoBehaviour
{
    #region Variables
    private Rigidbody rb;
    //private float currentSpeed, forward;

    //[SerializeField] private float maxSpeed;
    //[SerializeField] private float frictionValue;
    //[SerializeField] private float accelerationValue;
    //[SerializeField] private float brakeValue;

    //public IUserInput InputProxy { get; set; }

    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float acceleration;
    public float maxBrakeTorque= 10;
    public bool reverse;
    public TextMeshProUGUI speedometer;

    private float steering;
    private float motor, brake;
    private float accel = 0f;
    private float wheelCircumference;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        wheelCircumference = axleInfos[1].rightWheel.radius * 2.0f * 3.14f;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Debug.Log(Input.GetAxis("Throttle"));
        if (Input.GetKey(KeyCode.W))
        {
            accel += Time.deltaTime * acceleration;
            accel = Mathf.Clamp01(accel);            
        }
        else
        {
            accel -= Time.deltaTime * acceleration;
            accel = Mathf.Clamp01(accel);
        }

        motor = Mathf.Clamp(accel, 0, 1) * maxMotorTorque;
        */
        if(Input.GetButtonDown("Gear Up"))
        {
            reverse = true;
        }
        else if(Input.GetButtonDown("Gear Down"))
        {
            reverse = false;
        }
        if (Input.GetAxis("Throttle") > 0.1)
            motor = maxMotorTorque * Input.GetAxis("Throttle");
        else
        {
            brake = -Input.GetAxis("Throttle") * maxBrakeTorque;
            motor = 0f;
        }
        Debug.Log(motor);
        steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        
        ////float vertical = UserInput.GetAxis("Vertical");
        //forward = Input.GetAxis("Vertical");
        //if (forward > 0.1)
        //{
        //    if (currentSpeed < maxSpeed)
        //    {
        //        currentSpeed += forward;

        //    }
        //}
        //else if (forward < 0)
        //{
        //    if (currentSpeed > -maxSpeed)
        //    {
        //        currentSpeed -= forward;

        //    }
        //}
        //else if (currentSpeed != 0) currentSpeed += currentSpeed > 0 ? -frictionValue : frictionValue;
        ////if (currentSpeed < 0) currentSpeed = 0f;
        //rb.velocity = new Vector3(-currentSpeed, rb.velocity.y, rb.velocity.z);   


        //bool accelerate = Input.GetKey(KeyCode.W);
        //bool brake = Input.GetKey(KeyCode.S);

        //if (accelerate) currentSpeed += currentSpeed < (maxSpeed - accelerationValue) ? accelerationValue : 0;
        //else if (brake) currentSpeed -= currentSpeed > 0 ? brakeValue : 0f; 
        //rb.velocity = new Vector3(-currentSpeed, rb.velocity.y, rb.velocity.z);

        //if (currentSpeed >= frictionValue || currentSpeed < -frictionValue)
        //    currentSpeed += currentSpeed > 0 ? -frictionValue : frictionValue;
        //else currentSpeed = 0;
    }

    private void FixedUpdate()
    {
        foreach (AxleInfo info in axleInfos)
        {
            if(info.steering)
            {
                info.leftWheel.steerAngle = steering;
                info.rightWheel.steerAngle = steering;
            }    
            if(info.motor)
            {
                info.leftWheel.motorTorque = reverse ? motor : -motor;
                info.rightWheel.motorTorque = reverse ? motor : -motor;
                info.leftWheel.brakeTorque = brake;
                info.rightWheel.brakeTorque = brake;
            }
        }

        float speed = rb.velocity.magnitude;
        speed *= 3.6f;
        if (speed > 240)
            rb.velocity = (240 / 3.6f) * rb.velocity.normalized;
        speedometer.text = speed.ToString("F2");
    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}
