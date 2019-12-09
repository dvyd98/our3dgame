using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingTileMoveScript : TileBaseScript
{

    bool left;
    // Start is called before the first frame update
    void Start()
    {
        type = "sliding";
        count = 20;
        speed = 2.0f;
        if (Random.value > 0.5f) left = true;
        else left = false;
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
            count = 73;
        }
        
    }

    void OnTriggerEnter(Collider otherObj)
    {
        string otag = otherObj.tag;
        if (otag == ("Player") || otag == "jump" || otag == "sliding_extra")
        {
            otherObj.transform.parent = transform;
        }
    }

    void OnTriggerStay(Collider otherObj)
    {
        string otag = otherObj.tag;
        if (otag == ("Player") || otag == "jump" || otag == "sliding_extra")
        {
            otherObj.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider otherObj)
    {
        string otag = otherObj.tag;
        if (otag == ("Player") || otag == "jump")
        {
            otherObj.transform.parent = null;
        }
    }
}
