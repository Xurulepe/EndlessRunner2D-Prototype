using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float initialSpawnInterval;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float minimumSpawnInterval = 0.5f;
    private float timer;
    
    private void Start()
    {
        initialSpawnInterval = spawnInterval;
        GameManager.Instance.OnGameStarted.AddListener(ResetSpawner);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    private void SpawnObstacle()
    {
        GameObject spawnedObstacle = ObstaclePool.Instance.GetPooledObstacle();
        if (spawnedObstacle != null)
        {
            spawnedObstacle.transform.position = transform.position;
            spawnedObstacle.transform.rotation = Quaternion.identity;
            spawnedObstacle.SetActive(true);
        }
    }

    public void DecreaseSpawnInterval(float multiplier)
    {
        spawnInterval *= multiplier;
        spawnInterval = Mathf.Max(spawnInterval, minimumSpawnInterval);
    }

    private void ResetSpawner()
    {
        spawnInterval = initialSpawnInterval;
        timer = 0f;
    }
}
