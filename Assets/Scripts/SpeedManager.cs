//using System.Collections;
//using UnityEngine;

//public class SpeedManager : MonoBehaviour
//{
//    // Start is called once before the first execution of Update after the MonoBehaviour is created

//    private ParallaxM para;
//    private backgroundMove bM;
//    private Obstacle1 obs;
//    private Fuel1 fuel;
//    private Coin1 coin;

//    void Start()
//    {
//        para = FindFirstObjectByType<ParallaxM>();
//        bM = FindFirstObjectByType<backgroundMove>();
//        obs = FindFirstObjectByType<Obstacle1>();
//        fuel = FindFirstObjectByType<Fuel1>();
//        coin = FindFirstObjectByType<Coin1>();

//        StartCoroutine(SpeedUp());
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    IEnumerator SpeedUp()
//    {
//        float currSpeed = 2f;
//        while(true)
//        {
//            yield return new WaitForSeconds(10);

//            para.SpeedHelper(currSpeed);
//            bM.SpeedHelper(currSpeed);
//            obs.SpeedHelper(currSpeed);
//            fuel.SpeedHelper(currSpeed);
//            coin.SpeedHelper(currSpeed);

//            currSpeed += 1;
//        }
//    }
//}



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
            currSpeed += 1;

            yield return new WaitForSeconds(10);

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
