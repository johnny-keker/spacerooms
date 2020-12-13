using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFirst : MonoBehaviour
{
    public GameObject Sensor;
    public GameObject Door;
    public GameObject Terminal;

    private UICanvas _canvas;
    private Player _player;
    private Terminal _terminal;

    private GameObject _door2;

    void Start()
    {
        Cursor.visible = false;

        _canvas = GameObject.FindGameObjectWithTag("CANVAS").GetComponent<UICanvas>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        var door = Instantiate(Door, new Vector3(15, 0, 0), Quaternion.identity);
        door.GetComponent<Door>().Setup();

        var doorSensor = Instantiate(Sensor, new Vector3(10, 0, -12), Quaternion.identity).GetComponent<Sensor>();
        doorSensor.CallbackOnEnter = () => StartCoroutine(door.GetComponent<Door>().Open());
        doorSensor.CallbackOnLeave = () => StartCoroutine(door.GetComponent<Door>().Close());

        _door2 = Instantiate(Door, new Vector3(-15, 0, 0), Quaternion.identity);
        _door2.GetComponent<Door>().Setup();

        _terminal = Instantiate(Terminal, new Vector3(-14f, 2f, 3.5f), Quaternion.AngleAxis(90f, new Vector3(0, 1, 0))).transform.GetChild(0).GetComponent<Terminal>();
        _terminal.OnUse = OnTerminalUse;
    }

    private void OnTerminalUse()
    {
        if (!_player.HasKey)
        {
            _canvas.SetError("I need a key!");
            return;
        }
        StartCoroutine(_door2.GetComponent<Door>().Open());
        _terminal.SetGreenScreen();
    }

    void Update()
    {
        
    }
}
