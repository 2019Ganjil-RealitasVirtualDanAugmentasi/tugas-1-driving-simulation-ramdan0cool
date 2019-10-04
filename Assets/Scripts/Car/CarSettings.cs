using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Car/Settings", fileName="CarData")]
public class CarSettings : ScriptableObject
{
    [SerializeField] private float maxMotorTorque;
    [SerializeField] private float maxBrakeTorque;
    [SerializeField] private float maxSteeringAngle;

    public float MaxMotorTorque { get => maxMotorTorque;}
    public float MaxBrakeTorque { get => maxBrakeTorque;}
    public float MaxSteeringAngle { get => maxSteeringAngle;}
}
