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

    public UnityEvent OnGameStarted;
    public UnityEvent OnGameOver;

    [SerializeField] private GameObject obstacleSpawner;
    
    private void Update()
    {
        if (isGameRunning)
        {
            UpdateScore();
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

    public void StartGame()
    {
        isGameRunning = true;
        score = 0f;
        obstacleSpawner.SetActive(true);
        OnGameStarted?.Invoke();
    }

    public void GameOver()
    {
        isGameRunning = false;
        obstacleSpawner.SetActive(false);
        OnGameOver?.Invoke();
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
