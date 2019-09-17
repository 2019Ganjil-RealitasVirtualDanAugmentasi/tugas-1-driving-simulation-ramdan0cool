﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarControl : MonoBehaviour
{
    #region Variables
    //private Rigidbody rb;
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
    public bool reverse;

    private float steering;
    private float motor;
    float accel = 0f;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
    //    rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            accel += Time.deltaTime * acceleration;
            accel = Mathf.Clamp01(accel);
            motor = Mathf.Clamp(accel, 0, 1) * maxMotorTorque;
        }
        else
        {
            accel -= Time.deltaTime * acceleration;
            accel = Mathf.Clamp01(accel);
            motor = 0;
        }
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
        //float motor = maxMotorTorque * -Input.GetAxis("Vertical");

        foreach (AxleInfo info in axleInfos)
        {
            if(info.steering)
            {
                info.leftWheel.steerAngle = steering;
                info.rightWheel.steerAngle = steering;
            }    
            if(info.motor)
            {
                info.leftWheel.motorTorque = -motor;
                info.rightWheel.motorTorque = -motor;
            }
        }
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
