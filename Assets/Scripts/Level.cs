using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject Sensor;

    void Start()
    {
        var doorSensor = Instantiate(Sensor, new Vector3(10, 0, -12), Quaternion.identity).GetComponent<Sensor>();
        doorSensor.CallbackOnEnter = () => Debug.Log("Player entered");
        doorSensor.CallbackOnLeave = () => Debug.Log("Player leaved");
    }

    void Update()
    {
        
    }
}
