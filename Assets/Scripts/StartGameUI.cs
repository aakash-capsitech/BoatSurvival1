using UnityEngine;

public class StartGameUI : MonoBehaviour
{
    [Header("UI References")]
    public GameObject gameplayHUD;
    public GameObject startUI;
    public GameObject gameOverUI;

    void Start()
    {
        Time.timeScale = 0f;
        AudioListener.pause = false;

        startUI.SetActive(true);
        if (gameOverUI != null) gameOverUI.SetActive(false);
        if (gameplayHUD != null) gameplayHUD.SetActive(false);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;

        startUI.SetActive(false);
        if (gameplayHUD != null) gameplayHUD.SetActive(true);
    }
}
