using UnityEngine;

public class Obstacle1 : MonoBehaviour
{
    public float rotationSpeed = 200f;
    public bool useYRotation = true;
    public float floatAmplitude = 0.2f;
    public float floatFrequency = 2f;
    public float fallSpeed;
    public bool enableGlow = true;
    public float glowSpeed = 2f;
    public float glowIntensity = 0.3f;

    private SpriteRenderer sr;
    private Color baseColor;
    private float initialY;

    //public GameManager gameManager;
    private LifeManager lifeManager;

    private ObstacleSound oSound;
    private DestructionManager destructionManager;

    void Start()
    {
        fallSpeed = SpeedManager.currSpeed;
        sr = GetComponent<SpriteRenderer>();
        baseColor = sr.color;
        initialY = transform.position.y;

        lifeManager = FindFirstObjectByType<LifeManager>();
        oSound = FindFirstObjectByType<ObstacleSound>();

        destructionManager = FindFirstObjectByType<DestructionManager>();
        DestructionManager.trackedObjects.Add(gameObject);
    }

    void Update()
    {
        fallSpeed = SpeedManager.currSpeed;
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

    public void SpeedHelper(float x)
    {
        fallSpeed = x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("player"))
        {
            Destroy(gameObject); ;
        }
        
        if (collision.gameObject.CompareTag("Player"))
        {
            //gameManager.GetComponent<GameOverS>().GameOver();
            lifeManager.TakeDamage();
            Destroy(gameObject);
            //audioS.GetComponent<AudioSource>().Play();
            oSound.PlaySound();
        }
    }
}
