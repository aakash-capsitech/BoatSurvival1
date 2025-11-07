using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Coin Settings")]
    public GameObject coinPrefab;
    public int coinCount = 5;
    public float spawnInterval = 2f;
    public float minX = -1.3f;
    public float maxX = 1.3f;
    public float y = 10f;

    [Header("Fuel Settings")]
    public GameObject FuelPrefab;
    public GameObject fuelIcon;
    public GameObject fuelBarrelPrefab;
    public float fuelEmptyTimer = 5f;
    private GameObject[] fuelArray;
    private int fuelCount = 5;

    private GameOverS gameOverScript;
    public TextMeshProUGUI scoreText;
    public int score;

    public GameObject[] obstacles;

    public TextMeshProUGUI muteText;

    private HealthBar hb;

    void Start()
    {

        hb = FindFirstObjectByType<HealthBar>();

        fuelArray = new GameObject[5];
        StartCoroutine(SpawnCoin());
        StartCoroutine(SpawnFuel());
        FillFuel();
        StartCoroutine(EmptyFuel());
        StartCoroutine(UpdateScore());
        StartCoroutine(SpawnObstacles());
        gameOverScript = GetComponent<GameOverS>();
    }

    IEnumerator UpdateScore()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);
            score += 1;
            scoreText.text = "Score: " + score;
        }
    }

    IEnumerator SpawnObstacles()
    {
        float baseDelay = 2.5f;
        float randomOffset = 0.4f;

        while (true)
        {
            yield return new WaitForSeconds(baseDelay + Random.Range(-randomOffset, randomOffset));
            if(baseDelay > 1.0f)
            {
                baseDelay -= 0.1f;
            }
            

            int randIndex = Random.Range(0, obstacles.Length);
            float randX = Random.Range(-1.5f, 1.5f);

            Instantiate(obstacles[randIndex], new Vector3(randX, 10f, 0f), Quaternion.identity);
        }
    }

    IEnumerator SpawnCoin()
    {
        float baseDelay = 1.8f;
        float randomOffset = 0.3f;

        while (true)
        {
            yield return new WaitForSeconds(baseDelay + Random.Range(-randomOffset, randomOffset));

            float x = Random.Range(-1.3f, 1.3f);
            Vector3 spawnPos = new Vector3(x, 10f, 0f);

            Instantiate(coinPrefab, spawnPos, Quaternion.identity);
        }
    }


    IEnumerator SpawnFuel()
    {
        while (true)
        {
            yield return new WaitForSeconds(fuelEmptyTimer * 2.5f);
            Vector3 spawnPos = new Vector3(0, 10, 0);
            Instantiate(fuelBarrelPrefab, spawnPos, Quaternion.identity);
        }
    }

    public void FillFuel()
    {
        for (int i = 0; i < fuelCount; i++)
        {
            if (fuelArray[i] == null)
            {
                Vector3 pos = new Vector3(
                    fuelIcon.transform.position.x + (i * 0.2f) + 0.4f,
                    fuelIcon.transform.position.y,
                    0
                );

                //fuelArray[i] = Instantiate(FuelPrefab, pos, Quaternion.identity);
            }
        }
    }

    IEnumerator EmptyFuel()
    {
        while (true)
        {
            yield return new WaitForSeconds(fuelEmptyTimer);

            if (fuelCount > 0)
            {
                fuelCount--;
                Destroy(fuelArray[fuelCount]);
                fuelArray[fuelCount] = null;
                hb.TakeDamage(20);
            }

            if (fuelCount <= 0)
            {
                Debug.Log("Game Over – Out of Fuel!");
                StopCoroutine(EmptyFuel());
                gameOverScript.GameOver();
            }
        }
    }

    public void AddFuel()
    {
        if (fuelCount < 5)
        {
            Vector3 pos = new Vector3(
                fuelIcon.transform.position.x + (fuelCount * 0.2f) + 0.4f,
                fuelIcon.transform.position.y,
                0
            );

            //fuelArray[fuelCount] = Instantiate(FuelPrefab, pos, Quaternion.identity);
            fuelCount++;
            hb.AddHealth(60);
        }
    }

    public void ToggleMute()
    {
        AudioListener.pause = !AudioListener.pause;
        if(muteText.text == "Sound: ON")
        {
            muteText.text = "Sound: OFF";
        }
        else
        {
            muteText.text = "Sound: ON";
        }
            Debug.Log("Audio muted: " + AudioListener.pause);
    }

}
