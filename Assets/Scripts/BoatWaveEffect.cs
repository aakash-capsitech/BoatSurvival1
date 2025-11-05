using UnityEngine;
using System.Collections;

public class BoatWaveEffect : MonoBehaviour
{
    [Header("Ripple Settings")]
    public GameObject ripplePrefab;   // Assign a circular sprite prefab
    public float spawnInterval = 0.3f;
    public float rippleLifetime = 1.5f;
    public float rippleGrowthSpeed = 1.5f;
    public float rippleFadeSpeed = 1.0f;
    public float rippleOffsetY = -0.1f; // Slightly below the boat

    private bool isSpawning = true;

    void Start()
    {
        if (ripplePrefab == null)
        {
            Debug.LogWarning("BoatWaveEffect: Please assign a ripplePrefab!");
            enabled = false;
            return;
        }

        StartCoroutine(SpawnRipples());
    }

    IEnumerator SpawnRipples()
    {
        while (isSpawning)
        {
            GameObject ripple = Instantiate(
                ripplePrefab,
                new Vector3(transform.position.x, transform.position.y + rippleOffsetY, 0),
                Quaternion.identity
            );

            StartCoroutine(AnimateRipple(ripple));

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator AnimateRipple(GameObject ripple)
    {
        SpriteRenderer sr = ripple.GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            Destroy(ripple, rippleLifetime);
            yield break;
        }

        Color color = sr.color;
        float elapsed = 0f;

        while (elapsed < rippleLifetime)
        {
            elapsed += Time.deltaTime;

            // Expand ripple
            ripple.transform.localScale += Vector3.one * rippleGrowthSpeed * Time.deltaTime;

            // Fade out
            color.a -= rippleFadeSpeed * Time.deltaTime;
            sr.color = color;

            yield return null;
        }

        Destroy(ripple);
    }
}
