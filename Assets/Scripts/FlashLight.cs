using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private bool _active = false;
    private Light _light;

    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_active)
            {
                _active = false;
                _light.intensity = 0;
            }
            else
            {
                _active = true;
                _light.intensity = 2;
            }
        }
    }
}
