using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject gameOverMenu;

    private void OnGUI()
    {
        scoreText.text = GameManager.Instance.GetScore();
    }

    private void HideMenus()
    {
        startMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    private void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void BackToStartMenu()
    {
        startMenu.SetActive(true);
        gameOverMenu.SetActive(false);
    }

    private void Start()
    {
        GameManager.Instance.OnGameStarted.AddListener(HideMenus);
        GameManager.Instance.OnGameOver.AddListener(ShowGameOverMenu);
    }
}
