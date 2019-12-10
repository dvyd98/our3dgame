using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilBehaviour : MonoBehaviour
{
    
    private int counter = 100;
    private float acc = 1.0f;
    private float speed = 1.0f;
    private int cont;

    private enum states {IDLE, FALLING, RISING};
    
    private int state;

    private AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        cont = counter;
        state = (int) states.IDLE;
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cont == 0)
        {
            state = (int) states.FALLING;
            cont = counter;
        }

        switch(state)
        {
            case (int) states.FALLING:
                if (transform.position.y > 0.4f)
                {
                    transform.Translate(0.0f, -speed * Time.deltaTime, 0.0f);
                    if (transform.position.y < 0.4f)
                    {
                        transform.position = new Vector3(transform.position.x, 0.4f, transform.position.z);
                    }
                }
                if (transform.position.y == 0.4f)
                {
                    audiosource.Play();
                    state = (int)states.RISING;
                }
                speed += acc;
                break;
            case (int) states.RISING:
                speed = acc;
                if (transform.position.y < 1.5f)
                {
                    transform.Translate(0.0f, speed * Time.deltaTime, 0.0f);
                    if (transform.position.y > 1.5f)
                    {
                        transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
                    }
                }
                if (transform.position.y == 1.5f)
                {
                    state = (int) states.IDLE;
                    cont = counter;
                }
                break;
            case (int) states.IDLE:
                cont--;
                break;
        }
    }
}
