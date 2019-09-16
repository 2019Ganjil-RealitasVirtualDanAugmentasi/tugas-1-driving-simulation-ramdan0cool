using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private CarSettings carSetting;

    private ICarInput carInput;
    private CarMotor carMotor;
    private CarPhysics carPhysic;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        carInput = new KeyboardInput();
        carMotor = new CarMotor(carInput, rb = GetComponent<Rigidbody>(), carSetting);
        carPhysic = new CarPhysics(carInput, rb);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        carInput.ReadInput();
        carMotor.Move();
        Debug.Log(rb.velocity.x);
        //carPhysic.Friction();
        //Friction();
        
    }

    
}