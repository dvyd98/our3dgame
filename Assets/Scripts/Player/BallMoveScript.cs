using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoveScript : MonoBehaviour
{
    public static bool canMove;
    public int currentLvlInspector;
    public static int currentLvl;
    public static string state;

    public static Rigidbody rb;
    float speed = 5f;
    bool isUnlocked;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        isUnlocked = false;
        canMove = false;
        state = "alive";
        currentLvl = currentLvlInspector;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //rb.velocity = transform.forward * speed;
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKeyUp("0"))
        {
            isUnlocked = !isUnlocked;
        }
        if (isUnlocked && canMove && state == "alive")
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
        else if (canMove && state == "alive")
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter(Collision otherObj)
    {
        string otag = otherObj.gameObject.tag;
        if (otag == ("magneticf"))
            transform.parent = otherObj.transform;
    }

    void OnCollisionStay(Collision otherObj)
    {
        string otag = otherObj.gameObject.tag;
        if (otag == ("magneticf"))
            transform.parent = otherObj.transform;
    }

    void OnCollisionExit(Collision otherObj)
    {
        string otag = otherObj.gameObject.tag;
        if (otag != "falling")
        transform.parent = null;

    }

}
