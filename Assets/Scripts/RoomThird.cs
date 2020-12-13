using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomThird : MonoBehaviour
{
    public GameObject Terminal;
    private ButtonsPuzzle _puzzle;


    void Start()
    {
        _puzzle = new ButtonsPuzzle(
                Instantiate(Terminal, new Vector3(-44, 1.5f, -7.5f), Quaternion.AngleAxis(90f, new Vector3(0, 1, 0))).transform.GetChild(0).GetComponent<Terminal>(),
                Instantiate(Terminal, new Vector3(-44, 1.5f, -2.5f), Quaternion.AngleAxis(90f, new Vector3(0, 1, 0))).transform.GetChild(0).GetComponent<Terminal>(),
                Instantiate(Terminal, new Vector3(-44, 1.5f,  2.5f), Quaternion.AngleAxis(90f, new Vector3(0, 1, 0))).transform.GetChild(0).GetComponent<Terminal>(),
                Instantiate(Terminal, new Vector3(-44, 1.5f,  7.5f), Quaternion.AngleAxis(90f, new Vector3(0, 1, 0))).transform.GetChild(0).GetComponent<Terminal>()
            );
    }

    void Update()
    {
        if (_puzzle.Solved)
        {
            Debug.Log("Yep!");
        }
    }
}
