using System;
using UnityEngine;

public interface Iinput
{
    Action<Vector3> OnMovementDirectionInput { get; set; }
    Action<Vector2> OnmOvementInput { get; set; }
}