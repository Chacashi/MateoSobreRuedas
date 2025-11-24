using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Referencias")]
    public Transform player;
    public SpriteRenderer playerRenderer;
    public Collider2D playerCollider;
    public PlayerDirections playerDirections;

    [Header("Collider especial para escena 5")]
    public GameObject colliderEspecial;

    [Header("Escenarios")]
    public GameObject[] escenarios;
    public Vector2[] posicionesJugador;

    [Header("Sprites")]
    public Sprite spriteEscena5;
    public Sprite spriteOriginal;

    [Header("Escalas por escena (Player)")]
    public Vector3 escalaEscena2 = new Vector3(1.290246f, 1.327132f, 1f);
    public Vector3 escalaEscena3 = new Vector3(1.59106f, 1.545271f, 1f);
    public Vector3 escalaEscena4 = new Vector3(1.038644f, 1.082462f, 1f);
    public Vector3 escalaEscena5 = new Vector3(1.351795f, 1.248187f, 1f);

    [Header("Ajuste de escala SOLO del sprite en escena 5")]
    public Vector3 ajusteSpriteEscena5 = new Vector3(0.8f, 0.8f, 1f);

    private Vector3 escalaOriginal;
    private Vector3 escalaSpriteOriginal;

    public int escenarioActual = 0;

    private void Start()
    {
        escalaOriginal = player.localScale;
        escalaSpriteOriginal = playerRenderer.transform.localScale;
        spriteOriginal = playerRenderer.sprite;

        if (colliderEspecial != null)
            colliderEspecial.SetActive(false);
    }

    public void CambiarEscenario(int indice)
    {
        CarCleaner.DestruirAutos(); 

        if (indice >= 0 && indice < escenarios.Length)
        {
            for (int i = 0; i < escenarios.Length; i++)
                escenarios[i].SetActive(false);

            escenarios[indice].SetActive(true);
            player.position = posicionesJugador[indice];

            if (indice == 1) player.localScale = escalaEscena2;
            else if (indice == 2) player.localScale = escalaEscena3;
            else if (indice == 3) player.localScale = escalaEscena4;
            else if (indice == 4) player.localScale = escalaEscena5;
            else player.localScale = escalaOriginal;

            if (indice == 4)
            {
                playerRenderer.sprite = spriteEscena5;

                playerRenderer.transform.localScale = ajusteSpriteEscena5;

                if (colliderEspecial != null)
                {
                    colliderEspecial.SetActive(true);
                    colliderEspecial.transform.position = player.position;
                    colliderEspecial.transform.SetParent(player);
                }

                playerCollider.enabled = false;
                playerDirections.bloquearAnimacion = true;
            }
            else
            {
                playerRenderer.sprite = spriteOriginal;

                playerRenderer.transform.localScale = escalaSpriteOriginal;

                if (colliderEspecial != null)
                {
                    colliderEspecial.SetActive(false);
                    colliderEspecial.transform.SetParent(null);
                }

                playerCollider.enabled = true;
                playerDirections.bloquearAnimacion = false;
            }

            escenarioActual = indice;
        }
    }
}
