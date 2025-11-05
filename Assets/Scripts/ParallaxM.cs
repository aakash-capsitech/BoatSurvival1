using UnityEngine;

public class ParallaxM : MonoBehaviour
{
    public GameObject background1;
    public GameObject background2;
    private float scrollSpeed;
    public float backgroundHeight = 9.8f;

    private Rigidbody2D rb1;
    private Rigidbody2D rb2;

    void Start()
    {
        scrollSpeed = SpeedManager.currSpeed;
        SpeedHelper(scrollSpeed);
    }

    public void SpeedHelper(float x)
    {
        Debug.Log("jhf");
        rb1 = background1.GetComponent<Rigidbody2D>();
        rb2 = background2.GetComponent<Rigidbody2D>();

        rb1.linearVelocity = new Vector2(0, -x);
        rb2.linearVelocity = new Vector2(0, -x);
    }

    void Update()
    {
        scrollSpeed = SpeedManager.currSpeed;
        SpeedHelper(scrollSpeed);

        if (background1.transform.position.y <= -backgroundHeight)
        {
            MoveToTop(background1, background2);
        }
        if (background2.transform.position.y <= -backgroundHeight)
        {
            MoveToTop(background2, background1);
        }

        //SpeedHelper(2f);
    }

    void MoveToTop(GameObject bgToMove, GameObject bgAbove)
    {
        bgToMove.transform.position = new Vector3(
            bgAbove.transform.position.x,
            bgAbove.transform.position.y + backgroundHeight,
            bgAbove.transform.position.z
        );
    }
}
