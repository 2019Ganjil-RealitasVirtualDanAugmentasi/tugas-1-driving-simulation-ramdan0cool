using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum InputEnum
{
    KEYBOARD,
    STEERING_WHEEL,
}

public class Car : MonoBehaviour
{
    [SerializeField] private CarSettings carSetting;
    [SerializeField] private List<AxleInfo> axleInfos;
    [SerializeField] private InputEnum inputChoice;
    [SerializeField] private Transform steeringWheel;
    [SerializeField] private TextMeshProUGUI speedometer;
    [SerializeField] private TextMeshProUGUI reverseDisplay;
    [SerializeField] private float maxSteeringDegree;

    private ICarInput carInput;
    private CarMotor carMotor;
    private CarVisual carVisual;

    // Start is called before the first frame update
    void Awake()
    {
        switch (inputChoice)
        {
            case InputEnum.KEYBOARD:
                carInput = new KeyboardInput();
                break;
            case InputEnum.STEERING_WHEEL:
                carInput = new SteeringWheelInput();
                break;
            default:
                break;
        }
        
        carMotor = new CarMotor(axleInfos, carInput, carSetting);
        carVisual = new CarVisual(steeringWheel, speedometer, GetComponent<Rigidbody>(), carInput, maxSteeringDegree, reverseDisplay);
        //carMotor = new CarMotor(carInput, rb = GetComponent<Rigidbody>(), carSetting);
        //carPhysic = new CarPhysics(carInput, rb);
    }

    // Update is called once per frame
    void Update()
    {
        carInput.ReadInput();
        carMotor.UpdateMotor();
        carVisual.UpdateVisual();
        //Debug.Log(rb.velocity.x);
        //carPhysic.Friction();
        //Friction();        
    }

    private void FixedUpdate()
    {
        carMotor.Move();
    }

}