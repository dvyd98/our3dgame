using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.CompareTag("obstacle"))
        {
            // TODO Game Over Screen
        }
    }
}
