using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;        

    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0, 1.5f, -2.5f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(player.transform.position + new Vector3(0, 0, 5));
        transform.position = player.transform.position + offset;
    }
}
