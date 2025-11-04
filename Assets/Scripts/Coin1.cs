//using UnityEngine;

//[RequireComponent(typeof(SpriteRenderer))]
//public class Coin1 : MonoBehaviour
//{
//    [Header("Rotation Settings")]
//    public float rotationSpeed = 200f;
//    public bool useYRotation = true;

//    [Header("Float Settings")]
//    public float floatAmplitude = 0.2f;
//    public float floatFrequency = 2f;

//    [Header("Movement Settings")]
//    public float fallSpeed = 1f;

//    [Header("Glow Settings")]
//    public bool enableGlow = true;
//    public float glowSpeed = 2f;
//    public float glowIntensity = 0.3f;

//    private SpriteRenderer sr;
//    private Color baseColor;
//    private float initialY;

//    void Start()
//    {
//        sr = GetComponent<SpriteRenderer>();
//        baseColor = sr.color;
//        initialY = transform.position.y;
//        gameObject.tag = "coin";
//    }

//    void Update()
//    {
//        if (useYRotation)
//            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
//        else
//            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

//        float floatOffset = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
//        transform.position = new Vector3(
//            transform.position.x,
//            transform.position.y + floatOffset * Time.deltaTime,
//            transform.position.z
//        );

//        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime, Space.World);

//        if (enableGlow)
//        {
//            float t = (Mathf.Sin(Time.time * glowSpeed) + 1f) / 2f;
//            sr.color = baseColor * (1 + t * glowIntensity);
//        }
//    }
//}





using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Coin1 : MonoBehaviour
{
    public float rotationSpeed = 200f;
    public bool useYRotation = true;
    public float floatAmplitude = 0.2f;
    public float floatFrequency = 2f;
    public float fallSpeed = 1f;
    public bool enableGlow = true;
    public float glowSpeed = 2f;
    public float glowIntensity = 0.3f;

    private SpriteRenderer sr;
    private Color baseColor;
    private float initialY;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        baseColor = sr.color;
        initialY = transform.position.y;
    }

    void Update()
    {
        if (useYRotation)
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        else
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        float floatOffset = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y + floatOffset * Time.deltaTime,
            transform.position.z
        );

        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime, Space.World);

        if (enableGlow)
        {
            float t = (Mathf.Sin(Time.time * glowSpeed) + 1f) / 2f;
            sr.color = baseColor * (1 + t * glowIntensity);
        }
    }
}
