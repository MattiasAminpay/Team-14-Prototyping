using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, Iinput
{
    public Action<Vector2> OnmOvementInput { get; set; }
    public Action<Vector3> OnMovementDirectionInput { get; set; }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
    private void Update()
    {
        GetMovementInput();
        GetMovementDirection();
    }
    private void GetMovementDirection()
    {
        var cameraForewardDirection = Camera.main.transform.forward;
        Debug.DrawRay(Camera.main.transform.position, cameraForewardDirection * 10, Color.red);
        var directionToMoveIn = Vector3.Scale(cameraForewardDirection, (Vector3.right + Vector3.forward));
        Debug.DrawRay(Camera.main.transform.position, cameraForewardDirection * 10, Color.blue);
        OnMovementDirectionInput?.Invoke(directionToMoveIn);
    }

    private void GetMovementInput()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        OnmOvementInput?.Invoke(input);
    }


}
