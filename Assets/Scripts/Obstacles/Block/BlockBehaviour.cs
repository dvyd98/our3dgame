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
