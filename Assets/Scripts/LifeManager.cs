using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    [Header("Heart Settings")]
    public GameObject heartPrefab;
    public int totalLives = 3;
    public Vector2 startOffset = new Vector2(1f, -1f);

    [Header("Cooldown Settings")]
    public float hitCooldown = 1.5f;

    private int currentLives;
    private bool canLoseLife = true;
    private GameObject[] heartInstances;

    private GameManager gameManager;

    void Start()
    {
        currentLives = totalLives;
        heartInstances = new GameObject[totalLives];

        for (int i = 0; i < totalLives; i++)
        {
            GameObject heart = Instantiate(heartPrefab, new Vector3(1 + (i * 0.3f), 3.21f, 0), Quaternion.identity);

            heartInstances[i] = heart;
        }

        gameManager = FindFirstObjectByType<GameManager>();
    }

    public void TakeDamage()
    {
        if (!canLoseLife) return;
        StartCoroutine(LoseLifeCoroutine());
    }

    private IEnumerator LoseLifeCoroutine()
    {
        canLoseLife = false;

        if (currentLives > 0)
        {
            currentLives--;
            if (heartInstances[currentLives] != null)
                Destroy(heartInstances[currentLives]);
        }

        if (currentLives <= 0)
        {
            Debug.Log("Game Over!");
            gameManager.GetComponent<GameOverS>().GameOver();
        }

        yield return new WaitForSeconds(hitCooldown);
        canLoseLife = true;
    }
}
