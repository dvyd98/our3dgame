using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoveScript : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        rb.velocity = transform.forward * speed;
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity += transform.right * -speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity += transform.right * speed;
        }
        //rb.AddForce(new Vector3(0.0f, 0.0f, 2) * speed);
        //rb.AddForce(new Vector3(moveHorizontal, 0.0f, 0.0f) * speed);
    }
}
