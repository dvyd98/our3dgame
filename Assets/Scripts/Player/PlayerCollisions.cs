using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    bool isGod;
    
    // Start is called before the first frame update
    void Start()
    {
        isGod = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("9"))
        {
            isGod = !isGod;
        }

        if (transform.position.y < -15)
        {
            MusicPlayerScript.sound_effectPlayer.PlayOneShot(MusicPlayerScript.death);
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }

    void OnTriggerEnter(Collider otherObj)
    {
        if (otherObj.gameObject.CompareTag("obstacle") && !isGod)
        {
            MusicPlayerScript.sound_effectPlayer.PlayOneShot(MusicPlayerScript.death);
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }
}
