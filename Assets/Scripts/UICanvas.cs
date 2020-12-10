using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    private GameObject _interactWithTerminal;

    void Start()
    {
        _interactWithTerminal = transform.GetChild(0).gameObject;
    }

    public void ToggleInteractWithTerminalVisibility()
    {
        _interactWithTerminal.SetActive(!_interactWithTerminal.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
