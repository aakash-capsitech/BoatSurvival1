using UnityEngine;

public class backgroundMove : MonoBehaviour
{
    private float speed = 1f;
    private Material mat;
    private float offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * speed) / 10f;

        mat.mainTextureOffset = new Vector2(0, offset);
    }
}
