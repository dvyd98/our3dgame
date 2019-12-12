using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBehaviour : MonoBehaviour
{
    Animation anim;
    float wait;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        foreach (AnimationState state in anim) {
            state.speed = 0.3F;
        }
        anim.Play("Armature|BajarGarra");
    }

    // Update is called once per frame
    void Update()
    {

    }

}
