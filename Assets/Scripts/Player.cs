using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ClonePrefab;

    private GameObject _clone;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (_clone == null)
            {
                _clone = Instantiate(ClonePrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                //_clone.transform.parent = transform.parent;
            }
            else
            {
                Destroy(_clone);
                _clone = null;
            }
        }
    }
}
