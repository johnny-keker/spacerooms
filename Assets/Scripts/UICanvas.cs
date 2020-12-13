using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour
{
    private GameObject _interactWithTerminal;
    private GameObject _interactWithTerminal_clone;
    private GameObject _error;
    private GameObject _key;
    private GameObject _theEnd;
    private GameObject _controls;

    void Start()
    {
        _interactWithTerminal = transform.GetChild(0).gameObject;
        _interactWithTerminal_clone = transform.GetChild(1).gameObject;
        _error = transform.GetChild(2).gameObject;
        _key = transform.GetChild(3).gameObject;
        _theEnd = transform.GetChild(4).gameObject;
        _controls = transform.GetChild(5).gameObject;
    }

    public void SetInteractWithTerminalVisibility(bool value)
    {
        _interactWithTerminal.SetActive(value);
    }
    public void SetInteractWithTerminalCloneVisibility(bool value)
    {
        _interactWithTerminal_clone.SetActive(value);
    }

    public void SetError(string message)
    {
        _error.GetComponent<Text>().text = message;
        StartCoroutine(ShowError());
    }

    public void FoundKey()
    {
        _key.SetActive(true);
        _error.GetComponent<Text>().color = Color.green;
        _error.GetComponent<Text>().text = "Found a key!";
        StartCoroutine(ShowError());
    }

    IEnumerator ShowError()
    {
        _error.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        _error.SetActive(false);
        _error.GetComponent<Text>().color = Color.red;
    }

    public void ToggleControls()
    {
        if (_theEnd.activeSelf) return;
        _controls.SetActive(!_controls.activeSelf);
    }

    public void TriggerEnd()
    {
        _interactWithTerminal.SetActive(false);
        _interactWithTerminal_clone.SetActive(false);
        _error.SetActive(false);
        _key.SetActive(false);
        _controls.SetActive(false);
        _theEnd.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
