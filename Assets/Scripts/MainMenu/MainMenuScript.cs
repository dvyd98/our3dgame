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
    public bool isTryAgainClicked;

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

        MusicPlayerScript.sound_effectPlayer.PlayOneShot(MusicPlayerScript.menu_sound);
        if (isPlayClicked)
        {
            SceneManager.LoadScene("LevelSelector", LoadSceneMode.Single);
        }
        else if (isLVL1Clicked)
        {
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        }
        else if (isLVL2Clicked)
        {
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }
        else if (isLVL3Clicked)
        {
            SceneManager.LoadScene("Level3", LoadSceneMode.Single);
        }
        else if (isQuitClicked)
        {
            PlayerPrefs.DeleteAll(); //we use this to reset settings to changes to the standalone player apply. Fucking retarded i know
            Application.Quit();
        }
        else if (isHowtoClicked)
        {
            SceneManager.LoadScene("Howtoplay", LoadSceneMode.Single);
        }
        else if (isBackClicked)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
        else if (isCreditsClicked)
        {
            SceneManager.LoadScene("Credits", LoadSceneMode.Single);
        }
        else if (isTryAgainClicked)
        {
            if (BallMoveScript.currentLvl == 1) SceneManager.LoadScene("Level1", LoadSceneMode.Single);
            else if (BallMoveScript.currentLvl == 2) SceneManager.LoadScene("Level2", LoadSceneMode.Single);
            else if (BallMoveScript.currentLvl == 3) SceneManager.LoadScene("Level3", LoadSceneMode.Single);
            else SceneManager.LoadScene("LevelSelector", LoadSceneMode.Single);
        }
    }
}
