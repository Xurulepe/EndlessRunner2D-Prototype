using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void OnGUI()
    {
        scoreText.text = GameManager.Instance.GetScore();
    }
}
