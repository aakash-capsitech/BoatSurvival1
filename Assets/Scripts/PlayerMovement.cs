//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{

//    public Camera cam;
//    public LayerMask groundLayer;
//    private Vector3 OgRotation;

//    private Rigidbody2D rbBoat;

//    private float currentZRotation = 180f;


//    private void Start()
//    {
//        OgRotation = transform.localEulerAngles;
//        rbBoat = transform.GetComponent<Rigidbody2D>();
//    }

//    void Update()
//    {
//        Vector3 pos = transform.position;
//        if(gameObject.CompareTag("Player"))
//        {
//            pos.y = -3f;
//        }

//        if (gameObject.CompareTag("d"))
//        {
//            pos.y = -4.6f;
//        }

//        transform.position = pos;

//        if (Input.GetMouseButtonDown(0))
//        {
//            Vector3 mousePos = Input.mousePosition;
//            float mid = Screen.width / 2f;

//            if (mousePos.x < mid)
//            {
//                RotatePlayerToMouseLeft();
//            }
//            else
//            {
//                RotatePlayerToMouse2();
//            }
//        }

//        transform.rotation = Quaternion.Euler(0f, 0f, currentZRotation);
//    }


//    void RotatePlayerToMouseLeft()
//    {
//        Vector3 currRotation = transform.localEulerAngles;
//        if(currRotation.z > 220f)
//        {
//            return;
//        }
//        Vector3 targetRotation = new Vector3(0, 0, 15);
//        transform.localEulerAngles += targetRotation;
//        rbBoat.linearVelocity = transform.right * 1f;
//    }

//    void RotatePlayerToMouse2()
//    {
//        Vector3 currRotation = transform.localEulerAngles;
//        if (currRotation.z < 140f)
//        {
//            return;
//        }
//        Vector3 targetRotation = new Vector3(0, 0, -15);
//        transform.localEulerAngles += targetRotation;
//        rbBoat.linearVelocity = -transform.right * 1f;
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("coin"))
//        {
//            Destroy(collision.gameObject);
//        }
//        Debug.Log("collided" + collision);
//        Debug.Log(collision.gameObject.tag);
//        rbBoat.linearVelocity = transform.right * 0f;
//    }
//}








using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Camera cam;
    public LayerMask groundLayer;
    private Vector3 OgRotation;

    private Rigidbody2D rbBoat;

    private float currentZRotation = 180f;

    [SerializeField] private float moveSpeed = 500f;


    private void Start()
    {
        OgRotation = transform.localEulerAngles;
        rbBoat = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 pos = transform.position;
        if (gameObject.CompareTag("Player"))
        {
            pos.y = -3f;
        }

        if (gameObject.CompareTag("d"))
        {
            pos.y = -4.6f;
        }

        transform.position = pos;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            float mid = Screen.width / 2f;

            if (mousePos.x < mid)
            {
                RotatePlayerToMouseLeft();
            }
            else
            {
                RotatePlayerToMouse2();
            }
        }

        transform.rotation = Quaternion.Euler(0f, 0f, currentZRotation);
    }


    //void RotatePlayerToMouseLeft()
    //{
    //    rbBoat.transform.position = new Vector3(rbBoat.transform.position.x - 0.33f, rbBoat.transform.position.y, 0f);
    //}

    //void RotatePlayerToMouse2()
    //{
    //    rbBoat.transform.position = new Vector3(rbBoat.transform.position.x + 0.33f, rbBoat.transform.position.y, 0f);
    //}


   

    void RotatePlayerToMouseLeft()
    {
        Vector3 targetPos = new Vector3(rbBoat.transform.position.x - 0.33f, rbBoat.transform.position.y, 0f);
        rbBoat.transform.position = Vector3.Lerp(rbBoat.transform.position, targetPos, moveSpeed);
    }

    void RotatePlayerToMouse2()
    {
        Vector3 targetPos = new Vector3(rbBoat.transform.position.x + 0.33f, rbBoat.transform.position.y, 0f);
        rbBoat.transform.position = Vector3.Lerp(rbBoat.transform.position, targetPos, moveSpeed);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
        }
        Debug.Log("collided" + collision);
        Debug.Log(collision.gameObject.tag);
        rbBoat.linearVelocity = transform.right * 0f;
    }
}
