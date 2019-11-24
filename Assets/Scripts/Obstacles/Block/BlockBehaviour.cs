﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider otherObj)
    {
        if (!otherObj.gameObject.CompareTag("Player"))
            transform.parent = otherObj.transform;
        else
        {
            // TODO Gameover Screen
        }
    }

    void OnTriggerStay(Collider otherObj)
    {
        string tag = otherObj.gameObject.tag;
        if (tag != "Player" && tag != "falling")
            transform.parent = otherObj.transform;
        else
        {
            // TODO Gameover Screen
        }
    }
}
