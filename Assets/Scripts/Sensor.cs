using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    private GameObject _cylinder;
    private Light _light;
    public Action CallbackOnEnter;
    public Action CallbackOnLeave;

    // Start is called before the first frame update
    void Start()
    {
        _cylinder = transform.GetChild(0).gameObject;
        _light = transform.GetChild(1).gameObject.GetComponent<Light>();
    }
    private void OnTriggerEnter(Collider other)
    {
        _light.color = Color.green;
        CallbackOnEnter();
    }

    private void OnTriggerExit(Collider other)
    {
        _light.color = Color.red;
        CallbackOnLeave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
