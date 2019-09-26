using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICarInput
{
    void ReadInput();
    float SteerInput { get; }
    float Throttle { get; }
    float Brake { get; }
    bool Reverse { get; }
}
