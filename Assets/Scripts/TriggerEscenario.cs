using System.Runtime.InteropServices;
using UnityEngine;

public class TriggerEscenario : MonoBehaviour
{
    public int indiceEscenario;
    public GameController controlador;

    [Header("Panel de Victoria")]
    public GameObject panelVictoria;

    [DllImport("__Internal")]
    private static extern void SetTime(string text);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (CompareTag("YouWin"))
        {
                panelVictoria.SetActive(true);
#if UNITY_WEBGL && !UNITY_EDITOR
                                    SetTime("");
#endif
            Time.timeScale = 0f; 

            return;
        }
        controlador.CambiarEscenario(indiceEscenario);
    }
}
