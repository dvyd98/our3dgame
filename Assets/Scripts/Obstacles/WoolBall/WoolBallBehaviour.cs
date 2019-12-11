using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoolBallBehaviour : MonoBehaviour
{
    float direction = -1.0f;
    public float speed = 3.0f;

    private float startingPosX;

    // Start is called before the first frame update
    void Start()
    {
        startingPosX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, 0.0f, 0.0f);
        if (transform.position.x > startingPosX + 2.0 || transform.position.x < startingPosX -2.0)
        {
            direction *= -1.0f;
        }
    }

}
