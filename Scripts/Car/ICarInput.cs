using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICarInput
{
    void ReadInput();
    bool Throttle { get; }
    bool Brake { get; }
}
