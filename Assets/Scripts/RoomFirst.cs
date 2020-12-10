using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFirst : MonoBehaviour
{
    public GameObject Sensor;
    public GameObject Door;

    void Start()
    {
        var door = Instantiate(Door, new Vector3(15, 0, 0), Quaternion.identity);
        door.GetComponent<Door>().Setup();

        var doorSensor = Instantiate(Sensor, new Vector3(10, 0, -12), Quaternion.identity).GetComponent<Sensor>();
        doorSensor.CallbackOnEnter = () => StartCoroutine(door.GetComponent<Door>().Open());
        doorSensor.CallbackOnLeave = () => StartCoroutine(door.GetComponent<Door>().Close());
    }

    void Update()
    {
        
    }
}
