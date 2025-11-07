using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{

    public GameObject powerUpPrefab;
    public static bool isPower = false;

    void Start()
    {
        StartCoroutine(SpawnPowerUp());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnPowerUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            GameObject powerG = Instantiate(powerUpPrefab, new Vector3(Random.Range(-1, 2), 10, 0), Quaternion.identity);
            //isPower = true;
        }
    }
}
