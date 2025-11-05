using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Power-Up Settings")]
    public float duration = 5f;          // How long the power-up lasts
    public GameObject playerPowerEffect; // Assign the "PowerUp" prefab (orange circle under player)

    public static bool isActive { get; private set; } = false; // Global status check
    public static PowerUp Instance;                           // Singleton reference

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Only activate if not already powered up
            if (!isActive)
            {
                StartCoroutine(ActivatePowerUp(collision.transform));
            }

            // Hide this power-up object once picked up
            gameObject.SetActive(false);
        }
    }

    private IEnumerator ActivatePowerUp(Transform player)
    {
        isActive = true;

        // Enable the orange circle visual (attach it under the player)
        if (playerPowerEffect != null)
        {
            playerPowerEffect.transform.SetParent(player);
            playerPowerEffect.transform.localPosition = Vector3.zero;
            playerPowerEffect.SetActive(true);
        }

        Debug.Log("Power-up activated!");

        // Wait for the power-up duration
        yield return new WaitForSeconds(duration);

        // Disable power-up
        if (playerPowerEffect != null)
            playerPowerEffect.SetActive(false);

        isActive = false;

        Debug.Log("Power-up ended!");
    }
}
