using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public bool isPlayClicked;
    public bool isLVL1Clicked;
    public bool isLVL2Clicked;
    public bool isLVL3Clicked;
    public bool isQuitClicked;
    public bool isBackClicked;
    public bool isHowtoClicked;
    public bool isCreditsClicked;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseUp()
    {

        MusicPlayerScript.musicPlayer.PlayOneShot(MusicPlayerScript.menu_sound);
        if (isPlayClicked)
        {
            SceneManager.LoadScene("LevelSelector", LoadSceneMode.Single);
        }
        if (isLVL1Clicked)
        {
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        }
        if (isLVL2Clicked)
        {
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }
        if (isLVL3Clicked)
        {
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }
        if (isQuitClicked)
        {
            Application.Quit();
        }
        if (isHowtoClicked)
        {
            SceneManager.LoadScene("Howtoplay", LoadSceneMode.Single);
        }
        if (isBackClicked)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
        if (isCreditsClicked)
        {
            SceneManager.LoadScene("Credits", LoadSceneMode.Single);
        }
    }
}
