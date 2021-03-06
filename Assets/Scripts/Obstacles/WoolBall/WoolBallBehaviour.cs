﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoolBallBehaviour : MonoBehaviour
{
    float direction = -1.0f;
    public float speed = 3.0f;

    private float startingPosX;
    Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        startingPosX = transform.position.x;
        anim = GetComponent<Animation>();
        foreach (AnimationState state in anim) {
            state.speed = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, 0.0f, 0.0f);
        if (transform.position.x > startingPosX + 2.0 || transform.position.x < startingPosX -2.0)
        {
            direction *= -1.0f;

            foreach (AnimationState state in anim) {
                state.speed *= -1;
            }
        }
    }

}
