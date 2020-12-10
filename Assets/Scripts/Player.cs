using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ClonePrefab;

    private GameObject _clone;
    private Terminal _terminal;
    private UICanvas _canvas;

    void Start()
    {
        _canvas = GameObject.FindGameObjectWithTag("CANVAS").GetComponent<UICanvas>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TERMINAL")
        {
            _terminal = other.gameObject.GetComponent<Terminal>();
            _canvas.SetInteractWithTerminalVisibility(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "TERMINAL")
        {
            _terminal = null;
            _canvas.SetInteractWithTerminalVisibility(false);
        }
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

        if (Input.GetKeyDown(KeyCode.E))
            if (_terminal != null) _terminal.Use();
    }
}
