using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < 100; i++)
        {
            Debug.Log(ServiceLocator.GetService<GameManager>().gameObject.name);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
