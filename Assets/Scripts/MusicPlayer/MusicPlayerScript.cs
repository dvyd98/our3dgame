using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerScript : MonoBehaviour
{
    public bool isMenu;
    public bool isLevel1;
    public bool isLevel2;
    public bool isLevel3;
    private static bool isMusicLoaded;
    public static AudioSource musicPlayer;
    public static AudioSource sound_effectPlayer;

    public static AudioClip death;
    public static AudioClip menu_sound;
    public static AudioClip mouseover;
    public static AudioClip jump;

    public static AudioClip level1_track;
    public static AudioClip level2_track;
    public static AudioClip level3_track;

    // Start is called before the first frame update
    void Start()
    {
        if (!isMusicLoaded)
        {
            DontDestroyOnLoad(gameObject);
            loadMusic();
        }
        playBackground();
        sound_effectPlayer.volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void loadMusic()
    {
        musicPlayer = gameObject.AddComponent<AudioSource>();
        sound_effectPlayer = gameObject.AddComponent<AudioSource>();
        menu_sound = (AudioClip)Resources.Load("menu_click");
        mouseover = (AudioClip)Resources.Load("mouseover");

        level1_track = (AudioClip)Resources.Load("level1_track");
        level2_track = (AudioClip)Resources.Load("level2_track");

        death = (AudioClip)Resources.Load("death");
        jump = (AudioClip)Resources.Load("jump");
        isMusicLoaded = true;
    }

    private void playBackground()
    {
        musicPlayer.Stop();

        if (isMenu)
        {
            //play menu music (if any)
        }
        else if (isLevel1)
        {
            musicPlayer.PlayOneShot(level1_track);
        }
        else if (isLevel2)
        {
            musicPlayer.PlayOneShot(level2_track);
        }
        else if (isLevel3)
        {

        }
    }
}
