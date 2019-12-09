using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBehaviour : MonoBehaviour
{
    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO bajar el brazo cada X tiempo
    }

    void OnTriggerEnter(Collider otherObj)
    {
        if (!otherObj.gameObject.CompareTag("Player"))
            transform.parent = otherObj.transform;
    }

    void OnTriggerStay(Collider otherObj)
    {
        if (!otherObj.gameObject.CompareTag("Player"))
            transform.parent = otherObj.transform;
    }
}
