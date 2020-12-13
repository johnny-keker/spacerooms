using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 lastMouse = new Vector3(255, 255, 255);
    float camSens = 0.25f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(0, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(0, transform.eulerAngles.y + lastMouse.y, 0);
        characterController.transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;

        if (!characterController.enabled) return;
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection *= speed;
        moveDirection = transform.worldToLocalMatrix.inverse * moveDirection;
        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
}