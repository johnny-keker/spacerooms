using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("I can use it");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
