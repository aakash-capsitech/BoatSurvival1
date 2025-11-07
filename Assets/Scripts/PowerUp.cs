using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Power-Up Settings")]
    public float duration = 5f;
    public GameObject playerPowerEffect;

    public static bool isActive { get; private set; } = false;
    public static PowerUp Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isActive)
            {
                StartCoroutine(ActivatePowerUp(collision.transform));
            }

            gameObject.SetActive(false);
        }
    }

    private IEnumerator ActivatePowerUp(Transform player)
    {
        isActive = true;

        if (playerPowerEffect != null)
        {
            playerPowerEffect.transform.SetParent(player);
            playerPowerEffect.transform.localPosition = Vector3.zero;
            playerPowerEffect.SetActive(true);
        }

        Debug.Log("Power-up activated!");

        yield return new WaitForSeconds(duration);

        // Disable power-up
        if (playerPowerEffect != null)
            playerPowerEffect.SetActive(false);

        isActive = false;

        Debug.Log("Power-up ended!");
    }
}
