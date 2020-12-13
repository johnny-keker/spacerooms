using System;
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

    private Color _activeColor = Color.green;
    private Color _nonActiveColor = Color.red;

    public Action CallbackOnEnter;
    public Action CallbackOnLeave;

    public bool PlayerInside => _playerInside;

    public void OverrideColor(Color color)
    {
        _activeColor = color;
        _nonActiveColor = color;
        _light.color = color;
    }

    // Start is called before the first frame update
    void Start()
    {
        _light = transform.GetChild(1).gameObject.GetComponent<Light>();
    }

    public void Setup()
    {
        if (_light == null)
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
                _light.color = _activeColor;
                CallbackOnEnter();
            }
            return;
        }
        else
        {
            Debug.Log("Player inside");
            _playerInside = true;
            if (!_cloneInside)
            {
                _light.color = _activeColor;
                CallbackOnEnter();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (--_objectsInside == 0)
        {
            _light.color = _nonActiveColor;
            if (other.tag == "CLONE")
                _cloneInside = false;
            else
            {
                Debug.Log("Player leave");
                _playerInside = false;
            }
            CallbackOnLeave();
        }
    }

    void Update()
    {
        if (_clone != null || !_cloneInside) return;
        _cloneInside = false;
        if (--_objectsInside == 0)
        {
            _light.color = _nonActiveColor;
            CallbackOnLeave();
        }
    }
}
