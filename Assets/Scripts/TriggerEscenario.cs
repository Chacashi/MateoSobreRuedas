using UnityEngine;

public class TriggerEscenario : MonoBehaviour
{
    public int indiceEscenario;
    public GameController controlador; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            controlador.CambiarEscenario(indiceEscenario);
        }
    }
}
