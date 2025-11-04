using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    [Header("UI References")]
    public GameObject gameOverUI; // Assign your GameOver UI object in Inspector

    private bool isGameOver = false;

    void Start()
    {
        if (gameOverUI != null)
            gameOverUI.SetActive(false); // Hide on start
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        // Activate GameOver UI
        if (gameOverUI != null)
            gameOverUI.SetActive(true);

        // Stop all gameplay
        Time.timeScale = 0f; // Pauses physics and Update()

        // Optional: Disable player control or movement scripts if needed
        // Example: FindObjectOfType<PlayerMovement>().enabled = false;
    }

    // Optional: Call this to restart or continue game
    public void RestartGame()
    {
        Time.timeScale = 1f;
        isGameOver = false;
        if (gameOverUI != null)
            gameOverUI.SetActive(false);
    }
}
