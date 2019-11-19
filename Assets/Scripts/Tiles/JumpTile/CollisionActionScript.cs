﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionActionScript : MonoBehaviour
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
        if (otherObj.gameObject.tag == "Player")
        {
            otherObj.rigidbody.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
        }
    }
}