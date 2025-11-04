//using UnityEngine;

//public class BoatBackgroundController : MonoBehaviour
//{
//    [Header("Background References")]
//    public GameObject background1;
//    public GameObject background2;
//    public float scrollSpeed = 1f;
//    public float backgroundHeight = 10f;

//    [Header("Boat Control")]
//    public Transform boat;
//    public float turnAngle = 15f;
//    public float maxTurn = 30f;

//    private float currentAngle = 180f;
//    private Rigidbody2D rb1;
//    private Rigidbody2D rb2;

//    private Rigidbody2D rbBoat;

//    void Start()
//    {
//        rb1 = background1.GetComponent<Rigidbody2D>();
//        rb2 = background2.GetComponent<Rigidbody2D>();

//        rbBoat = boat.GetComponent<Rigidbody2D>();

//        rb1.linearVelocity = Vector2.down * scrollSpeed;
//        rb2.linearVelocity = Vector2.down * scrollSpeed;
//    }

//    void Update()
//    {
//        HandleInput();
//        ScrollBackground();
//    }

//    void HandleInput()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            currentAngle -= turnAngle;
//            currentAngle = Mathf.Clamp(currentAngle, currentAngle - maxTurn, currentAngle+maxTurn);
//            boat.rotation = Quaternion.Euler(0, 0, currentAngle);
//            rbBoat.linearVelocity = -boat.up * 2f;
//        }

//        if (Input.GetMouseButtonDown(1))
//        {
//            currentAngle += turnAngle;
//            currentAngle = Mathf.Clamp(currentAngle, currentAngle - maxTurn, currentAngle+maxTurn);
//            boat.rotation = Quaternion.Euler(0, 0, currentAngle);
//            rbBoat.linearVelocity = -boat.up * 2f;
//        }
//    }

//    void ScrollBackground()
//    {
//        float angleRad = currentAngle * Mathf.Deg2Rad;
//        Vector2 direction = new Vector2(Mathf.Sin(angleRad), -Mathf.Cos(angleRad));

//        rb1.linearVelocity = direction * scrollSpeed;
//        rb2.linearVelocity = direction * scrollSpeed;

//        if (direction.y < 0)
//        {
//            if (background1.transform.position.y <= -backgroundHeight)
//                MoveToTop(background1, background2);
//            if (background2.transform.position.y <= -backgroundHeight)
//                MoveToTop(background2, background1);
//        }
//        else
//        {
//            if (background1.transform.position.y >= backgroundHeight)
//                MoveToBottom(background1, background2);
//            if (background2.transform.position.y >= backgroundHeight)
//                MoveToBottom(background2, background1);
//        }
//    }

//    void MoveToTop(GameObject bg, GameObject reference)
//    {
//        bg.transform.position = new Vector3(
//            bg.transform.position.x,
//            reference.transform.position.y + backgroundHeight,
//            bg.transform.position.z
//        );
//    }

//    void MoveToBottom(GameObject bg, GameObject reference)
//    {
//        bg.transform.position = new Vector3(
//            bg.transform.position.x,
//            reference.transform.position.y - backgroundHeight,
//            bg.transform.position.z
//        );
//    }
//}
