//using UnityEngine;

//public class GameOverScript : MonoBehaviour
//{
//    [Header("UI References")]
//    public GameObject gameOverUI;

//    private bool isGameOver = false;

//    void Start()
//    {
//        if (gameOverUI != null)
//            gameOverUI.SetActive(false);
//    }

//    public void GameOver()
//    {
//        if (isGameOver) return;

//        isGameOver = true;
//        if (gameOverUI != null)
//            gameOverUI.SetActive(true);

//        Time.timeScale = 0f;

//    }

//    public void RestartGame()
//    {
//        Time.timeScale = 1f;
//        isGameOver = false;
//        if (gameOverUI != null)
//            gameOverUI.SetActive(false);
//    }
//}
