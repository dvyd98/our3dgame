using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticTileForwardScript : MagneticTileBaseScript
{
    // Start is called before the first frame update
    void Start()
    {
        type = "forward";
        count = 5;
        speed = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouching && count > 0)
        {
            --count;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (count == 0)
        {
            count = 30;
            isTouching = false;
            done = true;
        }
    }

    void OnCollisionEnter(Collision otherObj)
    {
        if (done == false) isTouching = true;
    }

}
