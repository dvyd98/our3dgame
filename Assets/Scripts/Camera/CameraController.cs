using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;        

    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0, 4, -8);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(player.transform);
        transform.position = player.transform.position + offset;
    }
}
