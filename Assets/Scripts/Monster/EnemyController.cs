using UnityEngine;
using ScriptableObjectGen;
using Player;

public class EnemyController : MonoBehaviour
{
    //Animation
    [Header(" ===== Default Setting ===== ")]
    public Monsters MonsterType;

    //whether this enemy is chasing player
    public bool isActive;
    
    //whether this enemy is dead
    private bool isDead;
    
    //basic states
    private float health;
    private float maxhealth;
    private float chargeCount;
    
    public float chargeLimit;
    public float attackValue;
    public float LockDistance;
    public float ChargeDistance;
    public float moveSpeed;

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
        Vector3 des = new Vector3(ActorController.instance.gameObject.transform.position.x, this.transform.position.y, ActorController.instance.gameObject.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, des, moveSpeed * Time.deltaTime);
        
        //detect whether the player stand still
        if ((ActorController.instance.transform.position - transform.position).magnitude <= ChargeDistance)
        {
            chargeCount += Time.deltaTime;
            if (chargeCount >= chargeLimit)
            {
                chargeCount = 0;

                //active attack animation
                //animator.SetTrigger("enemyAttack");
                
                //player get hurt
                ActorController.instance.getHurt(attackValue);
                
            }
        }
    }

    private void DetectPlayer()
    {
        //if player get close, this enemy will start to action
        if ((ActorController.instance.transform.position - transform.position).magnitude <= LockDistance)
        {
            Debug.Log("ininininininini");
            isActive = true;
            
        }
        else
        {
            Debug.Log((ActorController.instance.transform.position - transform.position).magnitude);
            isActive = false;
        }
    }
    
    private void DetectDead()
    {
        if (health <= 0)
        {
            // dead animation
            
            // remove from object pool
            EnemySpawnManager.instance.RemoveFromPool(this.gameObject.name);
            
            //destroy this game Object
            //TODO
            
        }
    }
    

    public void getHurt(float damage)
    {
        health -= damage;
    }
    
}
