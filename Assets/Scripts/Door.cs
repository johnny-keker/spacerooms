using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private GameObject _leftPart;
    private GameObject _rightPart;

    void Start()
    {
        
    }

    public void Setup()
    {
        _leftPart = transform.GetChild(0).gameObject;
        _rightPart = transform.GetChild(1).gameObject;
    }
    
    public IEnumerator Open()
    {
        for (int i = 0; i <= 20; ++i)
        {
            _leftPart.transform.Translate(new Vector3(0, 0, 0.1f));
            _rightPart.transform.Translate(new Vector3(0, 0, -0.1f));
            yield return new WaitForSeconds(.05f);
        }
    }

    public IEnumerator Close()
    {
        for (int i = 0; i <= 20; ++i)
        {
            _leftPart.transform.Translate(new Vector3(0, 0, -0.1f));
            _rightPart.transform.Translate(new Vector3(0, 0, 0.1f));
            yield return new WaitForSeconds(.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
