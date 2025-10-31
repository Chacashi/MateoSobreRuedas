using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rb;
    private Transform playerTransform;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationDuration = 0.4f; // tiempo que dura el giro
    private bool isHorizontal = true;
    private bool isRotating = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = rb.GetComponent<Transform>();
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
        if (isRotating)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        // Movimiento restringido al eje actual
        Vector2 velocity = Vector2.zero;

        if (isHorizontal)
            velocity = new Vector2(movement.x * speed, 0);
        else
            velocity = new Vector2(0, movement.y * speed);

        rb.linearVelocity = velocity;
    }

    private void SetMovement(Vector2 newMovement)
    {
        if (isRotating)
        {
            // Ignorar inputs mientras gira
            return;
        }

        // Detectar intento de giro (presionando ambos ejes)
        if (newMovement.x != 0 && newMovement.y != 0)
        {
            if (isHorizontal && Mathf.Abs(newMovement.y) > 0f)
            {
                // Girar a vertical. Consumimos el input actual (lo limpiamos) para evitar movimiento instantáneo.
                StartCoroutine(RotateAndSwitchAxis(Vector2.up * Mathf.Sign(newMovement.y), false));
                movement = Vector2.zero; // limpiar input inmediatamente
                return;
            }
            else if (!isHorizontal && Mathf.Abs(newMovement.x) > 0f)
            {
                // Girar a horizontal
                StartCoroutine(RotateAndSwitchAxis(Vector2.right * Mathf.Sign(newMovement.x), true));
                movement = Vector2.zero;
                return;
            }
        }

        // Si no hay giro, actualizar el movimiento normalmente
        movement = newMovement;
    }

    private IEnumerator RotateAndSwitchAxis(Vector2 newDirection, bool switchToHorizontal)
    {
        isRotating = true;
        rb.linearVelocity = Vector2.zero;

        float targetAngle = Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg;
        Quaternion startRot = playerTransform.rotation;
        Quaternion endRot = Quaternion.Euler(0, 0, targetAngle);

        float elapsed = 0f;
        while (elapsed < rotationDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / rotationDuration);
            playerTransform.rotation = Quaternion.Lerp(startRot, endRot, t);
            yield return null;
        }

        playerTransform.rotation = endRot;

        // Cambiar eje después de terminar el giro
        isHorizontal = switchToHorizontal;
        isRotating = false;

        // Nota: movement ya fue limpiado antes de empezar el giro (consumido),
        // así evitamos que el personaje avance automáticamente al terminar.
    }
}
