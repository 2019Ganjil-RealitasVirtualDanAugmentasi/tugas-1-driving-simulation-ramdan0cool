using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : ICarInput
{
    public float Throttle { get; private set; }
    public float Brake { get; private set; }
    public float SteerInput { get; private set; }
    public bool Reverse { get; private set; }

    public void ReadInput()
    {
        Throttle = Brake = 0;
        if (Input.GetAxis("Vertical") > 0.1)
            Throttle = Input.GetAxis("Vertical");
        else
        {
            Brake = -Input.GetAxis("Vertical");
        }
        SteerInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.PageUp)) Reverse = false;
        else if (Input.GetKeyDown(KeyCode.PageDown)) Reverse = true;
    }
}