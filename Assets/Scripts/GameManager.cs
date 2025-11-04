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

    private GameOverScript gameOverScript;
    public TextMeshProUGUI scoreText;
    public int score;

    public GameObject[] obstacles;

    void Start()
    {
        fuelArray = new GameObject[5];
        StartCoroutine(SpawnCoin());
        StartCoroutine(SpawnFuel());
        FillFuel();
        StartCoroutine(EmptyFuel());
        StartCoroutine(UpdateScore());
        StartCoroutine(SpawnObstacles());
        gameOverScript = GetComponent<GameOverScript>();
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
        while(true)
        {
            yield return new WaitForSeconds(2);
            int randIndex = Random.Range(0, 3);
            int randPos = Random.Range(-1, 2);
            Instantiate(obstacles[randIndex], new Vector3(randPos, 10, 0), Quaternion.identity);
        }
    }

    IEnumerator SpawnCoin()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            float x = Random.Range(minX, maxX);
            Vector3 spawnPos = new Vector3(x, y, 0);
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

                fuelArray[i] = Instantiate(FuelPrefab, pos, Quaternion.identity);
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

            fuelArray[fuelCount] = Instantiate(FuelPrefab, pos, Quaternion.identity);
            fuelCount++;
        }
    }
}
