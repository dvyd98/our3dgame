using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public bool isPlayClicked;
    public bool isQuitClicked;
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
        if (isPlayClicked)
        {
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        }
        if (isQuitClicked)
        {
            Application.Quit();
        }
    }
}
