using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Terminal : MonoBehaviour
{
    public Action OnUse;

    private GameObject _greenScreen;
    private GameObject _redScreen;

    void Start()
    {
        _greenScreen = transform.parent.transform.GetChild(4).gameObject;
        _redScreen = transform.parent.transform.GetChild(5).gameObject;
    }

    public void SetGreenScreen()
    {
        _redScreen.SetActive(false);
        _greenScreen.SetActive(true);
    }

    public void SetRedScreen()
    {
        _greenScreen.SetActive(false);
        _redScreen.SetActive(true);
    }

    public void Use()
    {
        OnUse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
