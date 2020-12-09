﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    private Light _light;
    private int _objectsInside = 0;
    private GameObject _clone = null;
    private bool _cloneInside = false;
    private bool _playerInside = false;

    public Action CallbackOnEnter;
    public Action CallbackOnLeave;

    // Start is called before the first frame update
    void Start()
    {
        _light = transform.GetChild(1).gameObject.GetComponent<Light>();
    }
    private void OnTriggerEnter(Collider other)
    {
        _objectsInside++;
        if (other.tag == "CLONE")
        {
            _clone = other.gameObject;
            _cloneInside = true;
            if (!_playerInside)
            {
                _light.color = Color.green;
                CallbackOnEnter();
            }
            return;
        }
        else
        {
            _playerInside = true;
            if (!_cloneInside)
            {
                _light.color = Color.green;
                CallbackOnEnter();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (--_objectsInside == 0)
        {
            _light.color = Color.red;
            CallbackOnLeave();
        }
    }

    void Update()
    {
        if (_clone != null || !_cloneInside) return;
        _cloneInside = false;
        if (--_objectsInside == 0)
        {
            _light.color = Color.red;
            CallbackOnLeave();
        }
    }
}
