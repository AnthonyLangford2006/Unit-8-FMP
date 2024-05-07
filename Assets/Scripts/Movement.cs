using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;

public class Movement : MonoBehaviour
{
    public float xInput, yInput;
    public Transform collisionLeft;
    public Transform collisionRight;
    public LayerMask wallLayerMask;
    public bool touchingWall;
    public bool isMoving;
    public bool attack;
    public bool iAmCorrect;

    RaycastHit2D hitUp1;
    RaycastHit2D hitUp2;
    RaycastHit2D hit2;

    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sr;

    public int xSpeed = 3;
    public int ySpeed = 1;
    int originalXSpeed;
    int originalYSpeed;

    public PlayerState state;
    public enum PlayerState
    {
        idle,
        moving,
        attack
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        // Variable decleration

        isMoving = false;
        state = PlayerState.idle;
        originalXSpeed = xSpeed;
        originalYSpeed = ySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        iAmCorrect = state != PlayerState.attack;
        StateManager();


        Attack();
        Move();
        AnimatonManager();

    }
    void StateManager()
    {
        if (attack)
        {
            state = PlayerState.attack;
        }
        else if (isMoving)
        {
            state = PlayerState.moving;
        }
        else
        {
            state = PlayerState.idle;
        }
    }
    void Move()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        isMoving = xInput != 0f || yInput != 0f;

        var moveVector = new Vector3(xInput, yInput, 1.5f);

        rb.velocity = new Vector2(moveVector.x * xSpeed, moveVector.y * ySpeed);
    }
    void AnimatonManager()
    {

        if(state == PlayerState.idle)
        {
            anim.SetBool("wolk", false);
        }
        else if (state == PlayerState.moving)
        {
            anim.SetBool("wolk", true);
            xSpeed = originalXSpeed;
            ySpeed = originalYSpeed;
        }
        else if (state == PlayerState.attack)
        {
            xSpeed = 0;
            ySpeed = 0;
        }

        if (xInput != 0 || yInput != 0)
        {
            anim.SetBool("wolk", true);
        }
        else
        {
            anim.SetBool("wolk", false);
        }
        if (xInput == -1f)
        {
            sr.flipX = true;
        }
        else if (xInput == 1f)
        {
            sr.flipX = false;
        }
    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //  Play the punch animation, placeholder below
            attack = true;
            anim.SetTrigger("Punch");
        }
        // attack state ends when animation ends. (utilise sprites)
    }
   

    public void AttackEnd()
    {
        attack = false;
        Debug.Log("attacking = false");
    }
}
