using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelScript : MonoBehaviour
{
    private bool isTriggered;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        isTriggered = false;
        count = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
        {
            if (count == 0)
            {
                MusicPlayerScript.sound_effectPlayer.PlayOneShot(MusicPlayerScript.you_win);
                SceneManager.LoadScene("LevelBeat", LoadSceneMode.Single);
            }
            --count;
        }
    }

    void OnTriggerEnter(Collider otherObj)
    {
        isTriggered = true;
        BallMoveScript.canMove = false;
        SceneFaderScript.FadeOut();
    }
}
