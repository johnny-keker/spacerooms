using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneController : MonoBehaviour
{
    public float speed = 6.0f;

    private Terminal _terminal;
    private UICanvas _canvas;

    // Start is called before the first frame update
    void Start()
    {
        _canvas = GameObject.FindGameObjectWithTag("CANVAS").GetComponent<UICanvas>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TERMINAL")
        {
            _terminal = other.gameObject.GetComponent<Terminal>();
            _canvas.SetInteractWithTerminalCloneVisibility(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "TERMINAL")
        {
            _terminal = null;
            _canvas.SetInteractWithTerminalCloneVisibility(false);
        }
    }

    void Update()
    {
        transform.Translate(Vector3.right * Input.GetAxis("CloneVertical") * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * -Input.GetAxis("CloneHorizontal") * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.O))
            if (_terminal != null) _terminal.Use();
    }
}
