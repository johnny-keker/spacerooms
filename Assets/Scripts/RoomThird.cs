using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomThird : MonoBehaviour
{
    public GameObject Terminal;
    public GameObject Sensor;

    private ButtonsPuzzle _puzzle;
    private Terminal _teleporterControl;
    private Sensor _teleporter;
    private UICanvas _canvas;
    private GameObject _player;

    void Start()
    {
        _canvas = GameObject.FindGameObjectWithTag("CANVAS").GetComponent<UICanvas>();
        _player = GameObject.FindGameObjectWithTag("Player");

        _teleporter = Instantiate(Sensor, new Vector3(-30, 0, 0), Quaternion.identity).GetComponent<Sensor>();
        _teleporter.Setup();
        _teleporter.OverrideColor(Color.blue);
        _teleporter.CallbackOnEnter = () => {};
        _teleporter.CallbackOnLeave = () => {};

        var teleporter2 = Instantiate(Sensor, new Vector3(50, 0, -10), Quaternion.identity).GetComponent<Sensor>();
        teleporter2.Setup();
        teleporter2.OverrideColor(Color.yellow);
        teleporter2.CallbackOnEnter = () => {};
        teleporter2.CallbackOnLeave = () => {};

        _teleporterControl = Instantiate(Terminal, new Vector3(-30f, 1.5f, -14f), Quaternion.identity).transform.GetChild(0).GetComponent<Terminal>();
        _teleporterControl.Setup();
        _teleporterControl.OnUse = OnTeleporterControlUse;

        _puzzle = new ButtonsPuzzle(
                Instantiate(Terminal, new Vector3(-44, 1.5f, -7.5f), Quaternion.AngleAxis(90f, new Vector3(0, 1, 0))).transform.GetChild(0).GetComponent<Terminal>(),
                Instantiate(Terminal, new Vector3(-44, 1.5f, -2.5f), Quaternion.AngleAxis(90f, new Vector3(0, 1, 0))).transform.GetChild(0).GetComponent<Terminal>(),
                Instantiate(Terminal, new Vector3(-44, 1.5f, 2.5f), Quaternion.AngleAxis(90f, new Vector3(0, 1, 0))).transform.GetChild(0).GetComponent<Terminal>(),
                Instantiate(Terminal, new Vector3(-44, 1.5f, 7.5f), Quaternion.AngleAxis(90f, new Vector3(0, 1, 0))).transform.GetChild(0).GetComponent<Terminal>(),
                OnPuzzleSolve
            );
    }

    private void OnPuzzleSolve()
    {
        _teleporterControl.SetGreenScreen();
    }

    private void OnTeleporterControlUse()
    {
        if (!_puzzle.Solved)
        {
            _canvas.SetError("I need to set up 4 power sources to use teleporter");
            return;
        }
        if (!_teleporter.PlayerInside) return;

        var cc = _player.GetComponent<CharacterController>();
        cc.enabled = false;
        _player.transform.SetPositionAndRotation(new Vector3(50, 2, -10), Quaternion.identity);
        cc.enabled = true;
    }

    void Update()
    {

    }
}
