using UnityEngine;

public class backgroundMove : MonoBehaviour
{
    private float speed;
    private Material mat;
    private float offset;
    void Start()
    {
        speed = SpeedManager.currSpeed;
        mat = GetComponent<MeshRenderer>().material;
    }

    public void SpeedHelper(float x)
    {
        speed = x;
    }

    void Update()
    {
        speed = SpeedManager.currSpeed;

        offset += (Time.deltaTime * speed) / 10f;

        mat.mainTextureOffset = new Vector2(0, offset);
    }
}
