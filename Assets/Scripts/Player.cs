using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ClonePrefab;
    public bool HasKey = false;

    private GameObject _clone;
    private Terminal _terminal;
    private Chest _chest;
    private UICanvas _canvas;

    void Start()
    {
        _canvas = GameObject.FindGameObjectWithTag("CANVAS").GetComponent<UICanvas>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TERMINAL" || other.tag == "TERMINAL_END")
        {
            _terminal = other.gameObject.GetComponent<Terminal>();
            _canvas.SetInteractWithTerminalVisibility(true);
        }

        if (other.tag == "CHEST")
        {
            _chest = other.gameObject.GetComponent<Chest>();
            _canvas.SetInteractWithTerminalVisibility(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "TERMINAL" || other.tag == "TERMINAL_END")
        {
            _terminal = null;
            _canvas.SetInteractWithTerminalVisibility(false);
        }

        if (other.tag == "CHEST")
        {
            _chest = null;
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
        {
            if (_terminal != null) _terminal.Use();
            if (_chest != null) _chest.Use();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            _canvas.ToggleControls();
    }
}
