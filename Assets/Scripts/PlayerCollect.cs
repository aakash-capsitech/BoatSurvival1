using TMPro;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public int coins = 0;

    private PickUpSound pickUpSound;

    private void Start()
    {
        pickUpSound = FindFirstObjectByType<PickUpSound>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            Debug.Log("Coin collected!");
            coins += 1;
            coinText.text = ""+coins;
            pickUpSound.PlaySound();
        }

        if (other.CompareTag("fuel"))
        {
            Destroy(other.gameObject);
            Debug.Log("Fuel collected!");
            FindFirstObjectByType<GameManager>().AddFuel();
            FindFirstObjectByType<GameManager>().AddFuel();
            FindFirstObjectByType<GameManager>().AddFuel();
            pickUpSound.PlaySound();
        }
    }
}
