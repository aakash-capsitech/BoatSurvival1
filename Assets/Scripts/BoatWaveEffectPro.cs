using UnityEngine;
using System.Collections;

public class BoatWaveEffectPro : MonoBehaviour
{
    [Header("Main Ripple")]
    public GameObject ripplePrefab;
    public float rippleInterval = 0.4f;
    public float rippleLifetime = 1.5f;
    public float rippleGrowthSpeed = 1.4f;
    public float rippleFadeSpeed = 1.2f;
    public float rippleOffsetY = -0.1f;

    [Header("Wave Threads")]
    public GameObject waveThreadPrefab;
    public float threadInterval = 0.25f;
    public float threadLifetime = 1.5f;
    public Vector2 threadScaleRange = new Vector2(0.4f, 1.2f);
    public Vector2 threadSpeedRange = new Vector2(0.5f, 1.5f);
    public float threadFadeSpeed = 1f;
    public float threadOffsetY = -0.12f;

    void Start()
    {
        if (ripplePrefab)
            StartCoroutine(SpawnRipples());
        if (waveThreadPrefab)
            StartCoroutine(SpawnWaveThreads());
    }

    IEnumerator SpawnRipples()
    {
        while (true)
        {
            GameObject ripple = Instantiate(
                ripplePrefab,
                new Vector3(transform.position.x, transform.position.y + rippleOffsetY, 0),
                Quaternion.identity
            );
            StartCoroutine(AnimateRipple(ripple));
            yield return new WaitForSeconds(rippleInterval);
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

        Color c = sr.color;
        float elapsed = 0f;

        while (elapsed < rippleLifetime)
        {
            elapsed += Time.deltaTime;
            ripple.transform.localScale += Vector3.one * rippleGrowthSpeed * Time.deltaTime;
            c.a -= rippleFadeSpeed * Time.deltaTime;
            sr.color = c;
            yield return null;
        }
        Destroy(ripple);
    }

    IEnumerator SpawnWaveThreads()
    {
        while (true)
        {
            float xOffset = Random.Range(-0.4f, 0.4f);
            Vector3 spawnPos = new Vector3(transform.position.x + xOffset, transform.position.y + threadOffsetY, 0);

            GameObject thread = Instantiate(waveThreadPrefab, spawnPos, Quaternion.identity);
            thread.transform.localScale = new Vector3(Random.Range(threadScaleRange.x, threadScaleRange.y),
                                                      Random.Range(0.05f, 0.15f),
                                                      1f);

            float moveSpeed = Random.Range(threadSpeedRange.x, threadSpeedRange.y);
            StartCoroutine(AnimateWaveThread(thread, moveSpeed));

            yield return new WaitForSeconds(threadInterval);
        }
    }

    IEnumerator AnimateWaveThread(GameObject thread, float moveSpeed)
    {
        SpriteRenderer sr = thread.GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            Destroy(thread, threadLifetime);
            yield break;
        }

        Color c = sr.color;
        float elapsed = 0f;

        float dir = Random.value < 0.5f ? -1f : 1f;

        while (elapsed < threadLifetime)
        {
            elapsed += Time.deltaTime;

            thread.transform.position += new Vector3(dir * moveSpeed * Time.deltaTime, 0, 0);

            c.a -= threadFadeSpeed * Time.deltaTime;
            sr.color = c;

            yield return null;
        }

        Destroy(thread);
    }
}
