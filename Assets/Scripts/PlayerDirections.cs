using UnityEngine;

public class PlayerDirections : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    public bool bloquearAnimacion = false;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 currentMovement;
    private Animator animatorController;

    private void OnEnable()
    {
        InputHandler.OnMovement += HandleMovement;
        //ArduinoInput.OnMovementEncoder += HandleMovement;
    }
    private void OnDisable()
    {
        InputHandler.OnMovement -= HandleMovement;
        //ArduinoInput.OnMovementEncoder -= HandleMovement;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animatorController = GetComponent<Animator>();
    }

    private void Update()
    {
        if (bloquearAnimacion)
        {
            animatorController.enabled = false;
            return;
        }
        else
        {
            animatorController.enabled = true;
        }

        if (currentMovement.x > 0.01f)
        {
            spriteRenderer.flipX = false;
            animatorController.SetBool("isWalk", true);
        }
        else if (currentMovement.x < -0.01f)
        {
            spriteRenderer.flipX = true;
            animatorController.SetBool("isWalk", true);
        }
        else
        {
            animatorController.SetBool("isWalk", false);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = currentMovement * speed;
    }

    private void HandleMovement(Vector2 movement)
    {
        currentMovement = movement.normalized;
    }
}
