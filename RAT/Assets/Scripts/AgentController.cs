using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    Iinput input;
    AgentMovement movement;
    private void OnEnable()
    {
        input = GetComponent<Iinput>();
        movement = GetComponent<AgentMovement>();
        input.OnMovementDirectionInput += movement.HandleMovementDirection;
        input.OnmOvementInput += movement.HandleMovement;
    }
    private void OnDisable()
    {
        input.OnMovementDirectionInput -= movement.HandleMovementDirection;
        input.OnmOvementInput -= movement.HandleMovement;
    }
}
