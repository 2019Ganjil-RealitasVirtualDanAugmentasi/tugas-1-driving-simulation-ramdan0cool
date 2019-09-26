using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMotor
{
    private readonly ICarInput carInput;
    private readonly CarSettings carSetting;
    private readonly List<AxleInfo> axleInfo;


    private float motor, brake, steer;

    public CarMotor(List<AxleInfo> axleInfo, ICarInput carInput, CarSettings carSetting)
    {
        this.axleInfo = axleInfo;
        this.carInput = carInput;
        this.carSetting = carSetting;
    }

    public void UpdateMotor()
    {
        motor = carInput.Throttle * carSetting.MaxMotorTorque;
        brake = carInput.Brake * carSetting.MaxBrakeTorque;
        steer = carSetting.MaxSteeringAngle * carInput.SteerInput;
    }

    public void Move()
    {
        /*
        if (carInput.Throttle > 0.1)
            motor = carSetting.MaxMotorTorque * -carInput.Throttle;
        else
        {
            brake = carSetting.MaxBrakeTorque * carInput.Brake;
            motor = 0f;
        }
        steer = carSetting.MaxSteeringAngle * carInput.SteerInput;
        */
        foreach (AxleInfo info in axleInfo)
        {
            if (info.steering)
            {
                info.leftWheel.steerAngle = steer;
                info.rightWheel.steerAngle = steer;
            }
            if (info.motor)
            {
                info.leftWheel.motorTorque = !carInput.Reverse ? motor : -motor;
                info.rightWheel.motorTorque = !carInput.Reverse ? motor : -motor;
                info.leftWheel.brakeTorque = brake;
                info.rightWheel.brakeTorque = brake;
            }
        }
        motor = 0f;
    }
}