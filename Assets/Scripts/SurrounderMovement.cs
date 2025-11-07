using UnityEngine;

public class SurrounderMovement : MonoBehaviour
{
    private PlayerCollect player;
    void Start()
    {
        player = FindFirstObjectByType<PlayerCollect>();
    }

    void Update()
    {
        float posx = player.transform.position.x;
        transform.position = new Vector3(posx, transform.position.y, transform.position.z);
    }
}
