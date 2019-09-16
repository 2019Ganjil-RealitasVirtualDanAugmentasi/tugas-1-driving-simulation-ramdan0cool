using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPhysics
{
    private readonly ICarInput carInput;
    private readonly Rigidbody rb;
    private readonly float frictionValue = 1f;

    public CarPhysics(ICarInput carInput, Rigidbody rb)
    {
        this.carInput = carInput;
        this.rb = rb;
    }

    public void Friction()
    {
        float currentSpeed = rb.velocity.x;       
        if(!carInput.Throttle)
        {
            if (currentSpeed > frictionValue || currentSpeed < -frictionValue)
            {
                currentSpeed += currentSpeed > 0 ? -frictionValue : frictionValue;
                rb.velocity = new Vector3(currentSpeed, rb.velocity.y, rb.velocity.z);
            }
        }        
        else rb.velocity = new Vector3(0f, rb.velocity.y, rb.velocity.z);  
    }
}