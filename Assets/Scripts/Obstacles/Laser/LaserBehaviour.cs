using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    float direction = -1.0f;
    public float speed = 1f;
    public float limit = 35.0f;
    float angle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        angle += direction * speed;
        transform.eulerAngles = new Vector3(0.0f, 0.0f, angle);
        if (angle > limit || angle < -limit)
        {
            direction *= -1.0f;
        }
    }
}
