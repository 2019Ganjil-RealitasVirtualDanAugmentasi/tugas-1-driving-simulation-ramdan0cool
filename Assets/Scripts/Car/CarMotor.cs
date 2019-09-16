using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMotor
{
    private readonly ICarInput carInput;
    private readonly Rigidbody rigidbody;
    private readonly CarSettings carSetting;

    private float currentSpeed = 0f;

    public CarMotor(ICarInput carInput, Rigidbody carRB, CarSettings carSetting)
    {
        this.carInput = carInput;
        this.rigidbody = carRB;
        this.carSetting = carSetting;
    }

    public void Move()
    {
        if (carInput.Throttle)
            currentSpeed += currentSpeed < (carSetting.MaxSpeed - carSetting.AccelerationValue) ? carSetting.AccelerationValue : 0;

        else if (carInput.Brake)
            currentSpeed -= currentSpeed >= carSetting.BrakeValue ? carSetting.BrakeValue : 0f;

        rigidbody.velocity = new Vector3(currentSpeed, rigidbody.velocity.y, rigidbody.velocity.z) ;
    }
}