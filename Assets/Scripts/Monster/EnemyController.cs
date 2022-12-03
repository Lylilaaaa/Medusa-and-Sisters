using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float LockDistance;
    public float ChargeDistance;
    public float attackDamage; 
    private GameObject PlayerInstance;

    
    //whether this enemy is chasing player
    private bool isActive;
    
    //whether this enemy is dead
    private bool isDead;
    
    //basic states
    private float health;
    private float maxhealth;
    private float chargeCount;
    public float chargeLimit;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        // set the init health

        maxhealth = health;
        chargeCount = 0;
    }

    private void Update()
    {
        DetectPlayer();
        DetectDead();
        if (isActive)
        {
            EnemyAction();
        }
    }


    private void EnemyAction()
    {
        //move toward player 
        
        
        //detect whether the player stand still
        if ((PlayerInstance.transform.position - this.transform.position).magnitude <= ChargeDistance)
        {
            chargeCount += Time.deltaTime;
            if (chargeCount >= chargeLimit)
            {
                chargeCount = 0;

                //active attack animation

                //player get hurt

            }
        }

        //attack
        
        
    }

    private void DetectPlayer()
    {
        //if player get close, this enemy will start to action
        if ((PlayerInstance.transform.position - this.transform.position).magnitude <= LockDistance)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }
    }
    
    private void DetectDead()
    {
        if (health <= 0)
        {
            // dead animation

            // remove from object pool

            //
            
        }
    }

    //use for initialize
    public void setPlayerInstance(GameObject inputGO)
    {
        PlayerInstance = inputGO;
    }

    public void getHurt(float damage)
    {   
        
    }
    
}
