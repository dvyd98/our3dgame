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
    int iddleNextDrop;
    bool shooted;
    bool once;
    private AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        state = (int) states.IDLE;
        anim = GetComponent<Animation>();
        limit = 4;
        player = GameObject.FindGameObjectWithTag("Player");
        iddleNextDrop = 50;
        shooted = false;
        once = false;
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        float dist = Math.Abs(transform.position.z - player.transform.position.z);

        if (dist < limit && !shooted) state = (int)states.SHOOTING;

        switch(state) {
            case (int)states.IDLE: {
                if (!anim.IsPlaying("WaterStandBy")) {
                    if (iddleNextDrop-- == 0) {
                        anim.Play("WaterStandBy");
                        iddleNextDrop = 50;
                    }
                }
                break;
            }
            case (int)states.SHOOTING: {
                if (!shooted) {
                    foreach (AnimationState state in anim) {
                        state.speed = 1.5F;
                    }
                    if (!once) {
                        anim.Play("ShootWater");
                        audiosource.Play();
                        once = true;
                    }

                    if (anim.IsPlaying("ShootWater")){
                        // update mesh
                        Collider col = GetComponentInChildren<CapsuleCollider>();
                        col.transform.position -= new Vector3(0,0,-0.1f);
                    }

                    if (!anim.IsPlaying("ShootWater") && once) {
                        shooted = true;
                        foreach (AnimationState state in anim) {
                            state.speed = 1F;
                        }
                    }
                }
                
                state = (int) states.IDLE;
                break;
            }
        }
    }

    void OnTriggerEnter(Collider otherObj)
    {
        string otag = otherObj.tag;
        if (otag != ("Player") && otag != "magneticf" && otag != "magneticgroup" && otag != "obstacle")
            transform.parent = otherObj.transform;
    }

    void OnTriggerStay(Collider otherObj)
    {
        string otag = otherObj.tag;
        if (otag != ("Player") && otag != "magneticf" && otag != "magneticgroup" && otag != "obstacle")
            transform.parent = otherObj.transform;

    }


}
