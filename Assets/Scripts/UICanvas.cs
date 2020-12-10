using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    private GameObject _interactWithTerminal;
    private GameObject _interactWithTerminal_clone;

    void Start()
    {
        _interactWithTerminal = transform.GetChild(0).gameObject;
        _interactWithTerminal_clone = transform.GetChild(1).gameObject;
    }

    public void SetInteractWithTerminalVisibility(bool value)
    {
        _interactWithTerminal.SetActive(value);
    }
    public void SetInteractWithTerminalCloneVisibility(bool value)
    {
        _interactWithTerminal_clone.SetActive(value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
