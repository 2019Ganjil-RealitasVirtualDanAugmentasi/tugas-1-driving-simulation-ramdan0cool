using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Car/Settings", fileName="CarData")]
public class CarSettings : ScriptableObject
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float accelerationValue;
    [SerializeField] private float brakeValue;

    public float MaxSpeed { get => maxSpeed; }
    public float AccelerationValue { get => accelerationValue;}
    public float BrakeValue { get => brakeValue;}
}
