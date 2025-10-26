using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    private float movement;
    private Rigidbody2D rb;
    [SerializeField] private float speed;    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        InputHandler.OnMovement += SetMovement;
        
    }

    private void OnDisable()
    {
        InputHandler.OnMovement -= SetMovement;
    }

    private void FixedUpdate()
    {
      rb.linearVelocity = new Vector2(movement * speed, rb.linearVelocity.y);    
    }


    private void SetMovement(float movement)
    {
        this.movement = movement;
    }



}
