using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBaseScript : MonoBehaviour
{
    public string type;
    public float speed = 3;
    public bool isTouching = false;
    public int count;
    public bool done = false;
    public Vector3 velocity = new Vector3( 0, -1, 0 );
    public float gravity = 9.8f;
    // Start is called before the first frame update
    void Start()
    {
        type = "base";
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Translate(Vector3.up * -speed * Time.deltaTime);
    }
}
