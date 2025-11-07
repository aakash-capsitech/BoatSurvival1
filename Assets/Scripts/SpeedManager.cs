using System.Collections;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{

    public static float currSpeed = 1f;
    void Start()
    {
        StartCoroutine(SpeedUp());
    }

    IEnumerator SpeedUp()
    {
        while (true)
        {
            currSpeed += 0.1f;

            yield return new WaitForSeconds(1);

            foreach (var para in FindObjectsByType<ParallaxM>(FindObjectsSortMode.None))
                para.SpeedHelper(currSpeed);

            foreach (var bM in FindObjectsByType<backgroundMove>(FindObjectsSortMode.None))
                bM.SpeedHelper(currSpeed);

            foreach (var obs in FindObjectsByType<Obstacle1>(FindObjectsSortMode.None))
                obs.SpeedHelper(currSpeed);

            foreach (var fuel in FindObjectsByType<Fuel1>(FindObjectsSortMode.None))
                fuel.SpeedHelper(currSpeed);

            foreach (var coin in FindObjectsByType<Coin1>(FindObjectsSortMode.None))
                coin.SpeedHelper(currSpeed);

            
        }
    }
}
