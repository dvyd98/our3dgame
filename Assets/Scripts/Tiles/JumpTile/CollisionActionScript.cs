using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionActionScript : TileBaseScript
{
    // Start is called before the first frame update
    void Start()
    {
        type = "jump";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision otherObj)
    {
        if (!done)
        {
            if (otherObj.gameObject.tag == "Player" && PlayerCollisions.isGod == false)
            {
                otherObj.rigidbody.AddForce(new Vector3(0, 20, 0), ForceMode.Impulse);
                MusicPlayerScript.sound_effectPlayer.PlayOneShot(MusicPlayerScript.jump);
                done = true;
            }
        }
    }
}
