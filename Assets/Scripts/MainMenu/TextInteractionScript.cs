using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInteractionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseEnter()
    {
        MusicPlayerScript.musicPlayer.PlayOneShot(MusicPlayerScript.mouseover);
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
}
