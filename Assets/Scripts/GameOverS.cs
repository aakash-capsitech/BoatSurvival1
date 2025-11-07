using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverS : MonoBehaviour
{
    [Header("UI References")]
    public GameObject gameOverUI;
    public TextMeshProUGUI highScoretext;

    private bool isGameOver = false;
    private GameManager gm;

    void Start()
    {
        if (gameOverUI != null)
            gameOverUI.SetActive(false);

        gm = FindAnyObjectByType<GameManager>();
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        if (gameOverUI != null)
            gameOverUI.SetActive(true);

        Time.timeScale = 0f;
        AudioListener.pause = true;

        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);

        if (gm.score > savedHighScore)
        {
            PlayerPrefs.SetInt("HighScore", gm.score);
            PlayerPrefs.Save();
            highScoretext.text = "New High Score: " + gm.score;
        }
        else
        {
            highScoretext.text = "High Score: " + savedHighScore;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        isGameOver = false;
        AudioListener.pause = false;
        SpeedManager.currSpeed = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetGame()
    {
        Time.timeScale = 1f;
        isGameOver = false;

        if (gameOverUI != null)
            gameOverUI.SetActive(false);
    }
}
