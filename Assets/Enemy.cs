using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy : MonoBehaviour
{
    public bool playerInRange;
    public GameObject player;
    public float speed;
    public float stopDis;
    EnemyStates state;

    enum EnemyStates
    {
        Idle,
        Approach,
        Attack
    }

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        state = EnemyStates.Approach;
       
    }

    // Update is called once per frame
    void Update()
    {

        if (state == EnemyStates.Idle)
        {
            IdleState();
        }

        if (state == EnemyStates.Attack)
        {
            AttackState();
        }

        if (state == EnemyStates.Approach)
        {
            ApproachState();
        }
    }

    void ApproachState()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        bool inRange = Vector2.Distance(transform.position, player.transform.position) <= stopDis;


        if (inRange)
        {
            // start a delayed attack

            //exiting the approach state
            StartCoroutine("Test");
            state = EnemyStates.Attack;


        }
        else
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }


        // Do not collide with plaer. Only attack sprites can.




        if (playerInRange)
        {
            //Attack();
        }
        else
        {
            //ApproachPlayer();
        }

    }

    void IdleState()
    {
        //update

    }

    void AttackState()
    {
        //update

    }


    IEnumerator Test()
    {
        

        yield return new WaitForSeconds(3);
        print("do test delay");
        transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y - 0.5f);

        yield return null;
    }


    void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "player")
            playerInRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
            playerInRange = false;
    }

  
}



