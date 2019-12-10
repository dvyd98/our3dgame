﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelScript : MonoBehaviour
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
        MusicPlayerScript.sound_effectPlayer.PlayOneShot(MusicPlayerScript.you_win);
        SceneManager.LoadScene("LevelBeat", LoadSceneMode.Single);
    }
}
