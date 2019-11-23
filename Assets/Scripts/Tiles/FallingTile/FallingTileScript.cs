using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTileScript : TileBaseScript
{
    bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        type = "falling";
        count = 40;
        speed = 1.0f;
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            velocity.y -= gravity * Time.deltaTime;
            transform.parent.position += velocity * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.CompareTag("Player"))
        {
            isActive = true;
        }
    }
}
