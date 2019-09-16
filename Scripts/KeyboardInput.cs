using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : ICarInput
{
    public bool Throttle { get; private set; }
    public bool Brake { get; private set; }

    public void ReadInput()
    {
        Throttle = Input.GetKey(KeyCode.W);
        Brake = Input.GetKey(KeyCode.S);
    }
}