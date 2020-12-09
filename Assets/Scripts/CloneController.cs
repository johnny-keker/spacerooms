using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneController : MonoBehaviour
{
    public float speed = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.right * Input.GetAxis("CloneVertical") * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * -Input.GetAxis("CloneHorizontal") * Time.deltaTime * speed);
    }
}
