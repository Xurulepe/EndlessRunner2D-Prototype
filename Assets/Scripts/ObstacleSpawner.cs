using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefab;
    [SerializeField] private float spawnInterval = 2f;
    private float timer;

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
        GameObject spawnedObstacle = obstaclePrefab[Random.Range(0, obstaclePrefab.Length)];
        Instantiate(spawnedObstacle, transform.position, Quaternion.identity);
    }
}
