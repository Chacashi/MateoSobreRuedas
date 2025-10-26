using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public static event Action<float> OnMovement;

    public void Movement(InputAction.CallbackContext context)
    {
        float movement = context.ReadValue<float>();
        OnMovement?.Invoke(movement);
    }
}
