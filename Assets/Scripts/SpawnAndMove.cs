using UnityEngine;

public class SpawnAndMove : MonoBehaviour
{
    [Header("Asignar Prefabs (2D)")]
    public GameObject prefab1;
    public GameObject prefab2;

    [Header("Posiciones")]
    public Transform spawnPoint;   // Posición 1
    public Transform targetPoint;  // Posición 2

    [Header("Ajustes")]
    public float moveSpeed = 3f;

    [Header("Game Over")]
    public GameObject panelGameOver;

    private Vector3 startScale = new Vector3(0.1766777f, 0.1815201f, 1f);
    private Vector3 endScale = new Vector3(0.8158531f, 0.7194722f, 1f);

    void Start()
    {
        StartCoroutine(Spawner());
    }

    private System.Collections.IEnumerator Spawner()
    {
        while (true)
        {
            SpawnObject();

            // Random entre 3 y 5 segundos
            yield return new WaitForSeconds(Random.Range(3f, 5f));
        }
    }

    void SpawnObject()
    {
        GameObject prefabToSpawn = (Random.Range(0, 2) == 0) ? prefab1 : prefab2;

        GameObject obj = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
        obj.transform.localScale = startScale;

        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb == null)
            rb = obj.AddComponent<Rigidbody2D>();

        rb.gravityScale = 0;
        rb.bodyType = RigidbodyType2D.Kinematic;

        obj.AddComponent<MoveToTarget2D>().Setup(targetPoint, moveSpeed, startScale, endScale, panelGameOver);
    }
}
