using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingExtraTileScript : MonoBehaviour
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
        string tag = otherObj.gameObject.tag;
        if (tag == "jump")
        {
            transform.parent = otherObj.transform;
        }
        else if (tag == ("Player"))
        {
            otherObj.transform.parent = transform;
        }
    }

    void OnTriggerStay(Collider otherObj)
    {
        if (tag == "jump")
        {
            transform.parent = otherObj.transform;
        }
        else if (tag == ("Player"))
        {
            otherObj.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider otherObj)
    {
        if (tag == ("Player"))
        {
            otherObj.transform.parent = null;
        }
    }
}
