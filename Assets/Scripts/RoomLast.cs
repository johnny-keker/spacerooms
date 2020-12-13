using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLast : MonoBehaviour
{
    private Terminal _spaceshipTerminal;
    private GameObject _spaceship;
    private GameObject _player;
    private GameObject _gates;
    private UICanvas _canvas;
    private GameObject _particles1;
    private GameObject _particles2;

    void Start()
    {
        _canvas = GameObject.FindGameObjectWithTag("CANVAS").GetComponent<UICanvas>();
        _spaceship = GameObject.FindGameObjectWithTag("SPACESHIP_MODEL");
        _spaceshipTerminal = _spaceship.transform.GetChild(1).GetComponent<Terminal>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _gates = GameObject.FindGameObjectWithTag("GATES");
        _particles1 = _spaceship.transform.GetChild(2).gameObject;
        _particles2 = _spaceship.transform.GetChild(3).gameObject;

        _spaceshipTerminal.OnUse = TerminalUse;
    }

    private void TerminalUse()
    {
        _canvas.SetInteractWithTerminalVisibility(false);
        _player.GetComponent<CharacterController>().enabled = false;
        _player.transform.SetPositionAndRotation(_spaceship.transform.position, Quaternion.identity);
        _player.transform.SetParent(_spaceship.transform);
        StartCoroutine(SpaceshipFly());
    }

    IEnumerator SpaceshipFly()
    {
        for (int i = 0; i < 50; i++)
        {
            _gates.transform.Translate(new Vector3(0, -0.1f, 0));
            yield return new WaitForSeconds(.03f);
        }
        _canvas.TriggerEnd();
        _particles1.SetActive(true);
        _particles2.SetActive(true);
        for (int i = 0; i < 500; i++)
        {
            _spaceship.transform.Translate(new Vector3(0, 0, 0.1f));
            yield return null;
        }
    }

    void Update()
    {
        
    }
}
