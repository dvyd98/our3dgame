using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoveScript : MonoBehaviour
{
    public static Rigidbody rb;
    float speed = 5f;

    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        anim = gameObject.GetComponent<Animation>();
        foreach (AnimationState state in anim)
        {
            print(state);
            state.speed = 0.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //rb.velocity = transform.forward * speed;
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
        }
        //rb.AddForce(new Vector3(0.0f, 0.0f, 2) * speed);
        //rb.AddForce(new Vector3(moveHorizontal, 0.0f, 0.0f) * speed);
    }

    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.CompareTag("magneticf"))
            transform.parent = otherObj.transform;
        else if (otherObj.gameObject.CompareTag("falling"))
            transform.parent = otherObj.transform;
    }

    void OnCollisionStay(Collision otherObj)
    {
        if (otherObj.gameObject.CompareTag("magneticf"))
            transform.parent = otherObj.transform;
        else if (otherObj.gameObject.CompareTag("falling"))
            transform.parent = otherObj.transform;
    }
}
