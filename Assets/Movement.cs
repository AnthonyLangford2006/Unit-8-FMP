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


    RaycastHit2D hitUp1;
    RaycastHit2D hitUp2;
    RaycastHit2D hit2;

    Rigidbody2D body;

    public int speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        CollisionRaycast();
        Move();
        Attack();

        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        isMoving = (xInput != 1.5f|| yInput != 1.5f);

    }

    void Move()
    {

        if (isMoving)
        {
            var moveVector = new Vector3(xInput, yInput, 1.5f);
            body.MovePosition(new Vector3(transform.position.x + moveVector.x * speed * Time.deltaTime, transform.position.y + moveVector.y * speed * Time.deltaTime));

        }




        // complex controls due to the occupation of 2 Player controls
        // if (Input.GetKey("a")) // && (hit2.collider == null))
        {
            // print("Player pressed left");
            // transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            //anim.SetBool("Warrior Run", true);
            //sr.flipX = true;
        }

      // if (Input.GetKey("d")) //&& (!touchingWall))
        {
            //anim.speed = 2;
           // print("Player pressed right");
           // body.MovePosition(new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y));
            //anim.SetBool("Warrior Run", true);
            //sr.flipX = false;
        }

       // if (Input.GetKey("w")) //&& (hitUp1.collider == null) && (hitUp2.collider == null))
        {
            //anim.speed = 2;
           // print("Player pressed up");
           // transform.position = new Vector2(transform.position.x, transform.position.y + (speed * Time.deltaTime));
            //anim.SetBool("Warrior Run", true);
            //sr.flipX = false;
        }

       // if (Input.GetKey("s")) //&& (!touchingWall))
        {
            //anim.speed = 2;
           // print("Player pressed down");
           // transform.position = new Vector2(transform.position.x, transform.position.y - (speed * Time.deltaTime));
            //anim.SetBool("Warrior Run", true);
            //sr.flipX = false;
        }
    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //  Play the punch animation, placeholder below

            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y - 0.5f);
        }
    }
    void CollisionRaycast()
    {
        // Bottom cast

        //////float rayLength1 = 0.1f;

       // ////hitUp1 = Physics2D.Raycast(collisionLeft.position, Vector2.up, rayLength1, wallLayerMask);

       ////// Color hitColor1 = Color.red;

       ////// Debug.DrawRay(collisionLeft.position, Vector2.up * rayLength1, hitColor1);

       ////// hitUp2 = Physics2D.Raycast(collisionRight.position, Vector2.up, rayLength1, wallLayerMask);

        //////Color hitColor2 = Color.red;

       ///// Debug.DrawRay(collisionRight.position, Vector2.up * rayLength1, hitColor2);

        // Left cast



        /////float rayLength2 = 0.1f;

        ////hit2 = Physics2D.Raycast(collisionLeft.position, Vector2.left, rayLength2, wallLayerMask);

       //// Color hitColor3 = Color.red;

       //// Debug.DrawRay(collisionLeft.position, Vector2.left * rayLength2, hitColor2);
    }

}
