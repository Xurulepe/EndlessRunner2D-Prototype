using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance;

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
    #endregion

    private float score = 0f;
    public bool isGameRunning;

    [SerializeField] private float difficultyMultiplier = 0.95f;
    [SerializeField] private float difficultyIncreaseInterval = 30f;
    private float difficultyTimer;

    public UnityEvent OnGameStarted;
    public UnityEvent OnGameOver;

    [SerializeField] private GameObject obstacleSpawner;
    [SerializeField] private GameObject player;

    private void Start()
    {
        obstacleSpawner.SetActive(false);
        player.SetActive(false);
    }

    private void Update()
    {
        if (isGameRunning)
        {
            UpdateScore();
            UpdateDifficulty();
        }
    }

    private void UpdateScore()
    {
        score += Time.deltaTime;
    }

    public string GetScore()
    {
        return Mathf.RoundToInt(score).ToString();
    }

    public void ResetScore()
    {
        score = 0f;
    }

    private void UpdateDifficulty()
    {
        difficultyTimer += Time.deltaTime;

        if (difficultyTimer >= difficultyIncreaseInterval)
        {
            difficultyTimer = 0f;

            obstacleSpawner.GetComponent<ObstacleSpawner>().DecreaseSpawnInterval(difficultyMultiplier);
        }
    }

    public void StartGame()
    {
        isGameRunning = true;
        score = 0f;
        player.SetActive(true);
        obstacleSpawner.SetActive(true);
        OnGameStarted?.Invoke();
    }

    public void GameOver()
    {
        isGameRunning = false;
        player.SetActive(false);
        obstacleSpawner.SetActive(false);
        OnGameOver?.Invoke();
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
