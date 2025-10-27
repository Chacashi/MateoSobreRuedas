using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rb;
    private Transform playerRotation;
    [SerializeField] private float speed;
    private bool isHorizontal= true;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRotation = rb.GetComponent<Transform>();
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
        if (movement.x != 0 && movement.y != 0)
        {
            isHorizontal = !isHorizontal;
            return;
        }
            
        if(isHorizontal)
            rb.linearVelocity = new Vector2(movement.x * speed, rb.linearVelocity.y);
        else
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, movement.y * speed );


    }


    private void SetMovement(Vector2 movement)
    {
        this.movement = movement;
    }



}
