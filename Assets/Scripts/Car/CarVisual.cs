using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarVisual
{
    private readonly Transform steerTransform;
    private readonly TextMeshProUGUI speedometer, reverseDisplay;
    private readonly Rigidbody rigidbody;
    private readonly ICarInput carInput;
    private readonly float maxSteeringDegree;

    private readonly float initialRotationX, initialRotationY, initialRotationZ;

    public CarVisual(Transform steerTransform, TextMeshProUGUI speedometer, Rigidbody rigidbody, ICarInput carInput, float maxSteeringDegree, TextMeshProUGUI reverseDisplay)
    {
        this.steerTransform = steerTransform;
        this.speedometer = speedometer;
        this.reverseDisplay = reverseDisplay;
        this.rigidbody = rigidbody;
        this.carInput = carInput;
        this.maxSteeringDegree = maxSteeringDegree;
        initialRotationX = steerTransform.localRotation.eulerAngles.x;
        initialRotationY = steerTransform.localRotation.eulerAngles.y;
        initialRotationZ = steerTransform.localRotation.eulerAngles.z;
    }

    public void UpdateVisual()
    {
        float speed = rigidbody.velocity.magnitude;
        speed *= 3.6f;
        if (speed > 240)
            rigidbody.velocity = (240 / 3.6f) * rigidbody.velocity.normalized;
        speedometer.text = speed.ToString("F1");
        reverseDisplay.text = carInput.Reverse ? "R" : "";

        steerTransform.localRotation = Quaternion.Euler(new Vector3(initialRotationX + (maxSteeringDegree * carInput.SteerInput), initialRotationY, initialRotationZ));
        //steerTransform.rotation = Quaternion.Slerp(Quaternion.Euler(initialRotationX + maxSteeringDegree, steerTransform.rotation.eulerAngles.y, steerTransform.rotation.eulerAngles.z), Quaternion.Euler(initialRotationX - maxSteeringDegree, steerTransform.rotation.eulerAngles.y, steerTransform.rotation.eulerAngles.z), carInput.SteerInput);
    }
}
