using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSecond : MonoBehaviour
{
    public GameObject Terminal;

    private Terminal _terminal1;
    private Terminal _terminal2;
    private GameObject _light;

    private bool _t2Activated = false;

    void Start()
    {
        _light = transform.GetChild(0).gameObject;
        _terminal1 = Instantiate(Terminal, new Vector3(30, 2, 14), Quaternion.AngleAxis(180.0f, new Vector3(0, 1, 0))).transform.GetChild(0).GetComponent<Terminal>();
        _terminal2 = Instantiate(Terminal, new Vector3(30, 2, -14), Quaternion.identity).transform.GetChild(0).GetComponent<Terminal>();

        _terminal1.OnUse = () => StartCoroutine(Terminal1());
        _terminal2.OnUse = () => StartCoroutine(Terminal2());
    }

    IEnumerator Terminal1()
    {
        for (int i = 0; i < 20; ++i)
        {
            if (_t2Activated)
            {
                _light.SetActive(!_light.activeSelf);
                break;
            }
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator Terminal2()
    {
        _t2Activated = true;
        yield return new WaitForSeconds(2.0f);
        _t2Activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
