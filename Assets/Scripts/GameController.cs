using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Referencias")]
    public Transform player;

    [Header("Escenarios")]
    public GameObject[] escenarios;
    public Vector2[] posicionesJugador;

    private int escenarioActual = 0;

    public void CambiarEscenario(int indice)
    {
        if (indice >= 0 && indice < escenarios.Length)
        {
            for (int i = 0; i < escenarios.Length; i++)
                escenarios[i].SetActive(false);

            escenarios[indice].SetActive(true);

            player.position = posicionesJugador[indice];

            escenarioActual = indice;
        }
    }
}
