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
        string otag = otherObj.tag;
        if (otag == "jump")
        {
            transform.parent = otherObj.transform;
        }
        else if (otag == ("Player"))
        {
            otherObj.transform.parent = transform;
        }
    }

    void OnTriggerStay(Collider otherObj)
    {
        string otag = otherObj.tag;
        if (otag == "jump")
        {
            transform.parent = otherObj.transform;
        }
        else if (otag == ("Player"))
        {
            otherObj.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider otherObj)
    {
        string otag = otherObj.tag;
        if (otag == ("Player"))
        {
            otherObj.transform.parent = null;
        }
    }
}
