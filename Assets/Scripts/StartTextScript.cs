using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTextScript : MonoBehaviour
{
    private Text textDisplay;

    private int count;
    private bool visible;
    private bool isDone;
    // Start is called before the first frame update
    void Start()
    {
        textDisplay = GetComponent<Text>();
        count = 60;
        visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDone)
        {
            if (visible)
            {
                Color color = textDisplay.color;
                color.a -= 0.0167f;
                textDisplay.color = color;
            }
            else
            {
                Color color = textDisplay.color;
                color.a += 0.0167f;
                textDisplay.color = color;
            }
            if (count == 0)
            {
                visible = !visible;
                count = 60;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                BallMoveScript.canMove = true;
                textDisplay.enabled = false;
                isDone = true;
            }

            --count;
        }
    }
}
