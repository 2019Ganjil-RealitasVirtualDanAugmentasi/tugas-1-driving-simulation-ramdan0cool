using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheelInput : ICarInput
{
    public float Throttle { get; private set; }
    public float Brake { get; private set; }
    public float SteerInput { get; private set; }
    public bool Reverse { get; private set; }

    public void ReadInput()
    {
        Throttle = Brake = 0;
        if (Input.GetAxis("Throttle") > 0.1)
            Throttle = Input.GetAxis("Throttle");
        else
        {
            Brake = -Input.GetAxis("Throttle");
        }
        SteerInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Gear Up")) Reverse = false;
        else if (Input.GetButtonDown("Gear Down")) Reverse = true;
    }
}
