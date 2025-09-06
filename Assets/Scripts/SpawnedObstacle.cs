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

    private void Start()
    {
        GameManager.Instance.OnGameOver.AddListener(DesactiveGameObject);
    }

    void Update()
    {
        rb.linearVelocityX = -speed;

        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            DesactiveGameObject();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.GameOver();
        }
    }

    private void DesactiveGameObject()
    {
        timer = 0f;
        gameObject.SetActive(false);
    }
}
