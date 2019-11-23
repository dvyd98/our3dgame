using System.Collections;
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

    void OnCollisionEnter(Collision otherObj)
    {
        if (!otherObj.gameObject.CompareTag("Player"))
            transform.parent = otherObj.transform;
    }

    void OnCollisionStay(Collision otherObj)
    {
        if (!otherObj.gameObject.CompareTag("Player"))
            transform.parent = otherObj.transform;
    }

    void OnTriggerEnter(Collider otherObj)
    {
        if (!otherObj.gameObject.CompareTag("Player"))
            transform.parent = otherObj.transform;
        else
        {
            //BallMoveScript.rb.AddForce(new Vector3(0.0f, 0.0f, -1) * 100f);
        }
    }

    void OnTriggerStay(Collider otherObj)
    {
        string tag = otherObj.gameObject.tag;
        if (tag != "Player" && tag != "falling")
            transform.parent = otherObj.transform;
        else
        {
            //BallMoveScript.rb.AddForce(new Vector3(0.0f, 0.0f, -1) * 100f);
        }
    }
}
