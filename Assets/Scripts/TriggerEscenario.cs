using UnityEngine;

public class TriggerEscenario : MonoBehaviour
{
    public int indiceEscenario;
    public GameController controlador;

    [Header("Panel de Victoria")]
    public GameObject panelVictoria; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (CompareTag("YouWin"))
        {
                panelVictoria.SetActive(true);

            Time.timeScale = 0f; 

            return;
        }
        controlador.CambiarEscenario(indiceEscenario);
    }
}
