using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoveScript : MonoBehaviour
{
    public static bool canMove;
    public int currentLvlInspector;
    public static int currentLvl;
    public static string state;
    private bool doneJump;

    public static Rigidbody rb;
    float speed = 5f;
    bool isUnlocked;
    Animation anim;

    enum states {LEFT, FRONT, RIGHT};
    enum keys {A, W, S, D};

    states stateAnim;

    bool[] keyPressed = {false, false, false, false};
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        isUnlocked = false;
        canMove = false;
        doneJump = false;
        state = "alive";
        currentLvl = currentLvlInspector;
        anim = GetComponent<Animation>();
        stateAnim = states.FRONT;
    }

    // Update is called once per frame
    void Update()
    {
        onKeyDown();
        onKeyRelease();

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //rb.velocity = transform.forward * speed;
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKeyUp("0"))
        {
            isUnlocked = !isUnlocked;
        }
        if (state == "alive")
        {
            if (isUnlocked && canMove)
            {
                stateAnim = states.FRONT;
                if (keyPressed[(int)keys.W]) {
                    transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
                }
                if (keyPressed[(int)keys.S]) {
                    transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
                }
                if (keyPressed[(int)keys.A]) {
                    transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
                    stateAnim = states.LEFT;
                }
                if (keyPressed[(int)keys.D]) {
                    transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
                    stateAnim = states.RIGHT;
                }
            }
            else if (canMove)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
                stateAnim = states.FRONT;
                if (keyPressed[(int)keys.A]) {
                    transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
                    stateAnim = states.LEFT;
                }
                if (keyPressed[(int)keys.D]) {
                    transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
                    stateAnim = states.RIGHT;
                }
            }

            if (transform.position.y >= 1.92f && !doneJump)
            {
                rb.AddForce(new Vector3(0, -28, 0), ForceMode.Impulse);
                doneJump = true;
                foreach (AnimationState state in anim)
                {
                    state.speed = 0;
                }
            }
            else {
                doneJump = false;
                foreach (AnimationState state in anim)
                {
                    state.speed = 1;
                }
            }
        }
        else {
            foreach (AnimationState state in anim)
                {
                    state.speed = 0;
                }
        }

        switch(stateAnim) {
            case states.FRONT:
                if (!anim.IsPlaying("catWalkFront")) anim.Play("catWalkFront");
            break;
            case states.LEFT:
                if (!anim.IsPlaying("catWalkLeft")) anim.Play("catWalkLeft");
            break;
            case states.RIGHT:
                if (!anim.IsPlaying("catWalkRight")) anim.Play("catWalkRight");
            break;
        }
    }

    void OnCollisionEnter(Collision otherObj)
    {
        string otag = otherObj.gameObject.tag;
        if (otag == ("magneticf"))
            transform.parent = otherObj.transform;
    }

    void OnCollisionStay(Collision otherObj)
    {
        string otag = otherObj.gameObject.tag;
        if (otag == ("magneticf"))
            transform.parent = otherObj.transform;
    }

    void OnCollisionExit(Collision otherObj)
    {
        string otag = otherObj.gameObject.tag;
        if (otag != "falling")
            transform.parent = null;

    }

    private void onKeyDown() {
        if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.A)) keyPressed[(int) keys.A] = true;
        if (Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.S)) keyPressed[(int) keys.S] = true;
        if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.D)) keyPressed[(int) keys.D] = true;
        if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.W)) keyPressed[(int) keys.W] = true;
    }

    private void onKeyRelease() {
        if (Input.GetKeyUp(KeyCode.A)) keyPressed[(int) keys.A] = false;
        if (Input.GetKeyUp(KeyCode.S)) keyPressed[(int) keys.S] = false;
        if (Input.GetKeyUp(KeyCode.D)) keyPressed[(int) keys.D] = false;
        if (Input.GetKeyUp(KeyCode.W)) keyPressed[(int) keys.W] = false;
    }
}
