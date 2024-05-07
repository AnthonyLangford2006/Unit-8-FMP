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
    public EnemyStates state;
    float delay;

    public enum EnemyStates
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
        delay = 0;
       
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
        /*distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        */
       
        
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);



        // Do not collide with player. Only attack sprites can.
        if( PlayerInRange() == true )
        { 
            // start a delayed attack
            //exiting the approach state
            state = EnemyStates.Attack;
            delay = 3;
        }


    }

    void IdleState()
    {
        //update  Return to approach state when players leave attack state radius.

    }

    void AttackState()
    {
        // if delay is set, count down until zero
        if ( delay > 0 )
        {
            delay -= Time.deltaTime;

            // check if player has moved out of range
            if( PlayerInRange() == false )
            {
                state = EnemyStates.Approach;
            }
        }
        else
        {

            // do attack animation
            print("***attack!!!***");

        }
        // Utilise sprtes as a timer for when enemy can begin pursuing player again.
        
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

    bool PlayerInRange()
    {
         bool inRange = Vector2.Distance(transform.position, player.transform.position) <= stopDis;
         return inRange;
    }



  
}



