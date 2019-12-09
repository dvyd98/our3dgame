using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;        

    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0, 1, -2.5f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(0, 1, player.transform.position.z) + offset;

        transform.LookAt(player.transform.position + new Vector3(-player.transform.position.x,0,3));
    }
}
