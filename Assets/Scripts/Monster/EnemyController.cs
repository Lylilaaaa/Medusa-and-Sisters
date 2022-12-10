using System.Collections;
using Monster;
using UnityEngine;
using ScriptableObjectGen;
using Player;
using Manager;

public class EnemyController : MonoBehaviour
{
    //Animation
    [Header(" ===== Default Setting ===== ")]
    public Monsters MonsterType;
    public float stepCheckRange;
    public float stepCheckHeight;
    public float maxStepHeight;
    public bool _isStep;
    public GameObject groundSensor;

    [Header(" ===== Current Data ===== ")]
    public float currentHealth;
    private float attackTimer;
    private Animator anim;
    private GameObject model;
    private Rigidbody rig;
    public bool _isGrounded;


    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        // set the init health
        currentHealth = MonsterType.maxHealth;
        attackTimer = 0;
        model = transform.GetChild(0).gameObject;
        anim = model.GetComponent<Animator>();
    }

    private void Update()
    {
        _isGrounded = groundSensor.GetComponent<EnemyGroundDetect>().isGrounded;
        DetectPlayer();
        DetectDead();
        DetectAttack();
        if (MonsterType.isChasing)
        {
            EnemyAction();
        }
        //print("MonsterType.curHealth: "+MonsterType.curHealth);
    }


    private void EnemyAction()
    {
        anim.SetBool("move",true);
        //move toward player 
        Vector3 des = new Vector3(ActorController.instance.gameObject.transform.position.x, this.transform.position.y, ActorController.instance.gameObject.transform.position.z);
        Vector3 tempForward = ActorController.instance.gameObject.transform.position - model.transform.position;
        tempForward.y = 0;
        transform.position = Vector3.MoveTowards(transform.position, des, MonsterType.movingSpeed * Time.deltaTime);
        
        //rotate facing
        model.transform.forward = tempForward;
    }

    private void DetectPlayer()
    {
        //if player get close, this enemy will start to action
        if ((ActorController.instance.transform.position - transform.position).magnitude <= MonsterType.lockDistance && MonsterType.leastDistance <= (ActorController.instance.transform.position - transform.position).magnitude)
        {
            //lock
            MonsterType.isChasing = true;
            
        }
        else if((ActorController.instance.transform.position - transform.position).magnitude > MonsterType.lockDistance)
        {
            //Debug.Log((ActorController.instance.transform.position - transform.position).magnitude);
            MonsterType.isChasing = false;
            anim.SetBool("move",false);
            attackTimer = 0;
        }
        else
        {
            MonsterType.isChasing = false;
            anim.SetBool("move",false);
        }
    }

    private void DetectAttack()
    {
        //detect whether the player stand still
        if ((ActorController.instance.transform.position - transform.position).magnitude <= MonsterType.attackDistance)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= MonsterType.attackInterval)
            {
                attackTimer = 0;
                
                //player get hurt
                ActorController.instance.NextDamage =  MonsterType.damage;
                
                
                //active attack animation
                anim.SetTrigger("attack");
            }
        }
    }

    private void DetectDead()
    {
        if (currentHealth <= 0)
        {
            // dead animation
            
            // remove from object pool
            EnemySpawnManager.instance.RemoveFromPool(this.gameObject.name);
            anim.SetTrigger("dead");
            model.GetComponent<EnemyDie>().startDieAnim = true;
            //destroy this game Object
            //TODO

        }
    }
    
    public void getHurt(float damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("getHit");
    }
    
    private bool IsStep()
    {
        Ray ray = new Ray(transform.position + model.transform.forward.normalized * stepCheckRange + Vector3.up * stepCheckHeight, Vector3.down);
        RaycastHit hit;
        //point = Vector3.zero;

        if (!_isGrounded)
            return false;

        if (Physics.Raycast(ray, out hit, stepCheckHeight * 3, LayerMask.GetMask("Ground")))
        {
            float height = hit.point.y - rig.position.y;
            if (height < 0.06f)
                return false;

            if (height <= maxStepHeight)
            {
                //point = hit.point;
                return true;
            }
        }
        return false;
    }

    public IEnumerator PauseFrame() {
        //卡顿(降低动画速度)
        anim.speed = 0;

        //持续
        yield return new WaitForSeconds(0.2f);

        //恢复动画速度
        anim.speed = 1;
    }
    public void MonsOnAttackExit()
    {
        
        FxController.instance.QuitFx(6);
        //
    }
    public void OnDeadExit()
    {
        Destroy(gameObject);
    }
    
}
