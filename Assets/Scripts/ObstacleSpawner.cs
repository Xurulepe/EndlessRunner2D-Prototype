using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
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
        GameObject spawnedObstacle = ObstaclePool.Instance.GetPooledObstacle();
        if (spawnedObstacle != null)
        {
            spawnedObstacle.transform.position = transform.position;
            spawnedObstacle.transform.rotation = Quaternion.identity;
            spawnedObstacle.SetActive(true);
        }
    }
}
