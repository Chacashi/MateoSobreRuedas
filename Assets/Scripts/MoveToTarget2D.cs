using UnityEngine;

public class MoveToTarget2D : MonoBehaviour
{
    private Transform target;
    private float speed;

    private Vector3 startScale;
    private Vector3 endScale;

    private GameObject panel;

    private float destroyDistance = 0.05f;

    public void Setup(Transform targetPoint, float moveSpeed, Vector3 sScale, Vector3 eScale, GameObject panelGO)
    {
        target = targetPoint;
        speed = moveSpeed;
        startScale = sScale;
        endScale = eScale;
        panel = panelGO;

        CarCleaner.RegistrarAuto(gameObject); 
    }


    void Update()
    {
        if (target == null) return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        float journey = Vector3.Distance(transform.position, target.position);
        float t = 1 - (journey / 10f);
        t = Mathf.Clamp01(t);

        transform.localScale = Vector3.Lerp(startScale, endScale, t);

        if (Vector3.Distance(transform.position, target.position) < destroyDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
