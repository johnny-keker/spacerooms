using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSecond : MonoBehaviour
{
    public GameObject Terminal;
    public GameObject Chest;

    private Terminal _terminal1;
    private Terminal _terminal2;
    private Chest _chest;
    private GameObject _light;
    private UICanvas _canvas;
    private Player _player;

    private bool _t2Activated = false;

    void Start()
    {
        _canvas = GameObject.FindGameObjectWithTag("CANVAS").GetComponent<UICanvas>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        _light = transform.GetChild(0).gameObject;
        _terminal1 = Instantiate(Terminal, new Vector3(30, 2, 14), Quaternion.AngleAxis(180.0f, new Vector3(0, 1, 0))).transform.GetChild(0).GetComponent<Terminal>();
        _terminal2 = Instantiate(Terminal, new Vector3(30, 2, -14), Quaternion.identity).transform.GetChild(0).GetComponent<Terminal>();

        _chest = Instantiate(Chest, new Vector3(44.3f, 1.5f, -10.0f), Quaternion.identity).transform.GetChild(0).GetComponent<Chest>();

        _terminal1.Setup();
        _terminal2.Setup();
        _terminal1.OnUse = () => StartCoroutine(Terminal1());
        _terminal2.OnUse = () => StartCoroutine(Terminal2());
        _chest.OnUse = OnChestUse;
    }

    private void OnChestUse()
    {
        if (!_light.activeSelf)
        {
            _canvas.SetError("I need to turn electricity on to use it!");
            return;
        }
        _player.HasKey = true;
        _canvas.FoundKey();
    }

    IEnumerator Terminal1()
    {
        _terminal1.SetGreenScreen();
        for (int i = 0; i < 20; ++i)
        {
            if (_t2Activated)
            {
                _light.SetActive(!_light.activeSelf);
                break;
            }
            yield return new WaitForSeconds(.1f);
        }
        _terminal1.SetRedScreen();
    }

    IEnumerator Terminal2()
    {
        _terminal2.SetGreenScreen();
        _t2Activated = true;
        yield return new WaitForSeconds(2.0f);
        _t2Activated = false;
        _terminal2.SetRedScreen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
