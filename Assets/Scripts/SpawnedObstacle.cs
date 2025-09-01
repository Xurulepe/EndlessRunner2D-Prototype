using UnityEngine;

public class SpawnedObstacle : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifetime = 10f;
    private float timer;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.linearVelocityX = -speed;

        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            gameObject.SetActive(false);
            timer = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            Destroy(other.gameObject);
        }
    }
}
