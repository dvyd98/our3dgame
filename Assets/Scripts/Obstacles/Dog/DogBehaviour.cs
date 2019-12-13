using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBehaviour : MonoBehaviour
{
    Animation anim;
    float wait;
    int count;
    private AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        foreach (AnimationState state in anim) {
            state.speed = 0.3F;
        }
        anim.Play("Armature|BajarGarra");
        audiosource = GetComponent<AudioSource>();
        count = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 0)
        {
            audiosource.Play();
            count = 60;
        }
        --count;
    }

    void OnTriggerEnter(Collider otherObj)
    {
        string otag = otherObj.tag;
        if (otag != ("Player") && otag != "magneticf" && otag != "magneticgroup")
            transform.parent = otherObj.transform;
    }

    void OnTriggerStay(Collider otherObj)
    {
        string otag = otherObj.tag;
        if (otag != ("Player") && otag != "magneticf" && otag != "magneticgroup")
            transform.parent = otherObj.transform;

    }

}
