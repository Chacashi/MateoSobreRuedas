using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public static event Action<Vector2> OnMovement;

    public void Movement(InputAction.CallbackContext context)
    {
        Vector2 movement = context.ReadValue<Vector2>();
        OnMovement?.Invoke(movement);
    }
}
