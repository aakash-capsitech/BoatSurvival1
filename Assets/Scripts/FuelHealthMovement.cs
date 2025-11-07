using UnityEngine;

public class FuelHealthMovement : MonoBehaviour
{
    public GameObject player;
    public Camera mainCamera;

    void Update()
    {
        if (player == null || mainCamera == null)
            return;

        Vector3 screenPos = mainCamera.WorldToScreenPoint(player.transform.position);
        transform.position = new Vector3(screenPos.x, transform.position.y, transform.position.z);
    }
}
