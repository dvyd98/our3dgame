using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    bool isGod;
    int count;
    
    // Start is called before the first frame update
    void Start()
    {
        isGod = false;
        count = 60;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("9"))
        {
            isGod = !isGod;
            if (isGod) BallMoveScript.rb.useGravity = false;
            else BallMoveScript.rb.useGravity = true;
        }

        if (transform.position.y < -15)
        {
            MusicPlayerScript.sound_effectPlayer.PlayOneShot(MusicPlayerScript.death);
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
        if (BallMoveScript.state == "dying")
        {
            if (count == 0)
            {
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            }
            else --count;
        }
    }

    void OnTriggerEnter(Collider otherObj)
    {
        if (otherObj.gameObject.CompareTag("obstacle") && !isGod)
        {
            if (BallMoveScript.state != "dying")
            {
                MusicPlayerScript.sound_effectPlayer.PlayOneShot(MusicPlayerScript.death);
                Vector3 direction = gameObject.transform.position - otherObj.transform.position;
                direction *= 10;
                direction.y = 10;
                BallMoveScript.rb.AddForce(direction, ForceMode.Impulse);
                BallMoveScript.state = "dying";
            }
        }
    }
}
