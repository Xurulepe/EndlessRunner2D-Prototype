using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : ObjectPool
{
    public static ObstaclePool Instance;

    [SerializeField] private GameObject spikeObstaclePrefab;
    [SerializeField] private GameObject projectileObstaclePrefab;
    [SerializeField] private GameObject wallObstaclePrefab;

    [SerializeField] private GameObject pooledObstaclesParent;

    private List<GameObject> spikeObstacles;
    private List<GameObject> projectileObstacles;
    private List<GameObject> wallObstacles;

    private List<List<GameObject>> allObstaclesList;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        spikeObstacles = SetupPool(spikeObstaclePrefab, pooledObstaclesParent);
        projectileObstacles = SetupPool(projectileObstaclePrefab, pooledObstaclesParent);
        wallObstacles = SetupPool(wallObstaclePrefab, pooledObstaclesParent);

        allObstaclesList = new List<List<GameObject>>()
        {
            spikeObstacles,
            projectileObstacles,
            wallObstacles
        };
    }

    public GameObject GetPooledObstacle()
    {
        int randomIndex = Random.Range(0, allObstaclesList.Count);
        List<GameObject> randomObstacleList = allObstaclesList[randomIndex];
        return GetPooledObject(randomObstacleList);
    }
}
