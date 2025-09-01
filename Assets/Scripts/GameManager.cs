using UnityEngine;

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

    private void Update()
    {
        score += Time.deltaTime;
    }

    public string GetScore()
    {
        return Mathf.RoundToInt(score).ToString();
    }
}
