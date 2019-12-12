using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FireHydrantBehaviour : MonoBehaviour
{
    public GameObject player;
    public float limit;
    enum states {IDLE, SHOOTING}
    int state;
    Animation anim;
    int iddleNextDrop = 100;

    // Start is called before the first frame update
    void Start()
    {
        state = (int) states.IDLE;
        anim = GetComponent<Animation>();
        limit = 4;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        float dist = Math.Abs(transform.position.z - player.transform.position.z);
        print(String.Format("{0}, {1}", transform.position.z, player.transform.position.z));

        if (dist < limit) state = (int)states.SHOOTING;

        switch(state) {
            case (int)states.IDLE: {
                if (!anim.IsPlaying("WaterStandBy")) {
                    if (iddleNextDrop-- == 0) {
                        anim.Play("WaterStandBy");
                        iddleNextDrop = 100;
                    }
                }
                break;
            }
            case (int)states.SHOOTING: {
                anim.Play("ShootWater");
                break;
            }
        }
    }


}
