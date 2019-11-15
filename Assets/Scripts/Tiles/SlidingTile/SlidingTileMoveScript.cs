using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingTileMoveScript : MonoBehaviour
{
    int count;
    bool left;
    float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        count = 40;
        left = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (left)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        count--;
        if (count == 0)
        {
            left = !left;
            count = 120;
        }
        
    }
}
