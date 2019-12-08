using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerScript : MonoBehaviour
{
    public bool isMenu;
    public bool isLevel;
    private static bool isMusicLoaded;
    public static AudioSource musicPlayer;
    public static AudioClip menu_sound;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (!isMusicLoaded)
        {
            loadMusic();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void loadMusic()
    {
        if (isMenu)
        {
            musicPlayer = gameObject.AddComponent<AudioSource>();
            menu_sound = (AudioClip)Resources.Load("menu_click");
            isMusicLoaded = true;
        }
    }
}
