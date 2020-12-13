using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Action OnUse;

    void Start()
    {

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
