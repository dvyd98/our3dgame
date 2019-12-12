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
    enum statesMov {IDDLE, LEFT, FRONT, BACK, RIGHT};

    states stateAnim;
    statesMov stateMov;
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
        stateMov = statesMov.FRONT;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //rb.velocity = transform.forward * speed;
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);

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

        if (Input.GetKey(KeyCode.A)) stateMov = statesMov.LEFT;
        else {
            if (isUnlocked) stateMov = statesMov.IDDLE;
            else stateMov = statesMov.FRONT;
        }
        if (Input.GetKey(KeyCode.D)) stateMov = statesMov.RIGHT;
        else if (stateMov != statesMov.LEFT){
            if (isUnlocked) stateMov = statesMov.IDDLE;
            else stateMov = statesMov.FRONT;
        }
        if (Input.GetKey(KeyCode.W)) stateMov = statesMov.FRONT;
        if (Input.GetKey(KeyCode.S)) stateMov = statesMov.BACK;

        if (Input.GetKeyUp("0"))
        {
            isUnlocked = !isUnlocked;
        }
        if (state == "alive")
        {
            if (isUnlocked && canMove)
            {
                switch(stateMov) {
                    case statesMov.FRONT:
                    transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
                    stateAnim = states.FRONT;
                    break;
                    case statesMov.BACK:
                    transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
                    stateAnim = states.FRONT;
                    break;
                    case statesMov.LEFT:
                    transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
                    stateAnim = states.LEFT;
                    break;
                    case statesMov.RIGHT:
                    transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
                    stateAnim = states.RIGHT;
                    break;
                    case statesMov.IDDLE:
                    stateAnim = states.FRONT;
                    break;
                }
            }
            else if (canMove)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
                switch(stateMov) {
                    case statesMov.LEFT:
                    transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
                    stateAnim = states.LEFT;
                    break;
                    case  statesMov.RIGHT:
                    transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
                    stateAnim = states.RIGHT;
                    break;
                    default: stateAnim = states.FRONT; break;
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

}
