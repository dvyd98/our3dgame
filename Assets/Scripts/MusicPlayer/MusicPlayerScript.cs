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
    public bool isGameOver;
    private static bool isMusicLoaded = false;
    public static AudioSource musicPlayer;
    public static AudioSource sound_effectPlayer;

    public static AudioClip death;
    public static AudioClip menu_sound;
    public static AudioClip mouseover;
    public static AudioClip jump;
    public static AudioClip you_win;

    public static AudioClip menu_track;
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

        menu_track = (AudioClip)Resources.Load("menu_track");
        level1_track = (AudioClip)Resources.Load("level1_track");
        level2_track = (AudioClip)Resources.Load("level2_track");
        level3_track = (AudioClip)Resources.Load("level3_track");

        death = (AudioClip)Resources.Load("death");
        jump = (AudioClip)Resources.Load("jump");
        you_win = (AudioClip)Resources.Load("you_win");
        isMusicLoaded = true;
    }

    private void playBackground()
    {
        musicPlayer.volume = 1.0f;
        if (isMenu)
        {
            musicPlayer.volume = 0.2f;
            if (musicPlayer.isPlaying == false)
            {
                musicPlayer.loop = true;
                musicPlayer.clip = menu_track;
                musicPlayer.Play();
            }
        }

        else if (isLevel1)
        {
            musicPlayer.Stop();
            musicPlayer.PlayOneShot(level1_track);
        }
        else if (isLevel2)
        {
            musicPlayer.Stop();
            musicPlayer.PlayOneShot(level2_track);
        }
        else if (isLevel3)
        {
            musicPlayer.Stop();
            musicPlayer.PlayOneShot(level3_track);
        }
        else if (isGameOver)
        {
            musicPlayer.Stop();
        }
    }
}
