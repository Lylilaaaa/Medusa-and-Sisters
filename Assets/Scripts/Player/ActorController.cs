using Camera;
using UnityEngine;

namespace Player
{
    public class ActorController : MonoBehaviour
    {
        public IUserInput pi;
        public CameraController cameracCon;
        private Animator anim;
        private Rigidbody rigi;
        public GameObject model;
        private CapsuleCollider col;
        
        private Vector3 planerVec; //important!!
        private bool planerLook ;
        private Vector3 thrustVec;
        private float lerpTarget;
        private Vector3 deltaPos;

        [Header(" ===== Ability Setting ===== ")]
        public bool canRun;
        public bool canComboA1;
        public bool canComboA2;
        public bool canRoll;
        public bool canRollDistance;
        public bool canFreeAttack;
        
        private bool canAttack;
        

        [Header(" ===== Controller Speed Setting ===== ")]
        public float movingSpeed;
        public float runMultiplier = 2.5f;
        public float jumpVelocity;
        public float rollVelocity;
        public float lockRadius = 10f;

        [Space(10)]
        [Header(" ===== Friction Setting ===== ")]
        public PhysicMaterial frictionOne;
        public PhysicMaterial frictionZero;

        private void Awake()
        {
            IUserInput[]inputs = GetComponents<IUserInput>();
            foreach (var input in inputs)
            {
                if (input.enabled == true)
                {
                    pi = input;
                    break;
                }
            }
            anim = model.GetComponent<Animator>();
            rigi = GetComponent<Rigidbody>();
            col = GetComponent<CapsuleCollider>();
        }

        private void Update()
        {

            if (canRun)
            {
                anim.SetFloat("forward",
                    pi.Dmag * Mathf.Lerp(anim.GetFloat("forward"), ((pi.run) ? 2.0f : 1.0f),
                        0.5f)); //Smooth the process walk to run
                //print("enter canRun");
            }
            else
            {
                anim.SetFloat("forward", pi.Dmag);
            }
            
            
            //trigger signal
            if (pi.jump)
            {
                anim.SetTrigger("jump");
                canAttack = false;
            }
            if (pi.froll && canRoll)
            {
                anim.SetTrigger("forceroll");
                canAttack = false;
            }
            //只有在地面上才能攻击
            if (pi.attack && CheckState("ground") && canAttack)
            {
                anim.SetTrigger("attack");
            }

            else if (canFreeAttack && pi.attack)
            {
                anim.SetTrigger("attack");
            }
            
            // 呼叫camera脚本切换lock和unlock模式
            if (pi.Onlocked == true)
            {
                cameracCon.LockOnEnemy();
            }
            if(pi.Unlocked == true)
            {
                cameracCon.UnLockOnEnemy();
            }
            if (pi.Onlocking == true)
            {
                cameracCon.LockingOnEnemy();
            }

            //combo ability
            if (canComboA1 == true)
            {
                anim.SetBool("canComboA1",true);
            }
            else
            {
                anim.SetBool("canComboA1",false);
            }
            
            if (canComboA2 == true)
            {
                anim.SetBool("canComboA2",true);
            }
            else
            {
                anim.SetBool("canComboA2",false);
            }
            
            
            
            if (pi.Dmag > 0.1f)
            {
                model.transform.forward = Vector3.Slerp(model.transform.forward, pi.Dvec, 0.05f); //Smooth truning around;
            }
            if (planerLook == false)
            {
                if (canRun)
                {
                    planerVec = pi.Dmag * model.transform.forward * movingSpeed *
                                ((pi.run) ? runMultiplier : 1.0f); //player input (both mag and direction)
                }
                else
                {
                    planerVec = pi.Dmag * model.transform.forward * movingSpeed;
                }
            } 
        }
        
        //查询当前状态
        private bool CheckState(string stateName, string layerName = "Base Layer")
        {
            int layerIndex = anim.GetLayerIndex(layerName);
            bool result = anim.GetCurrentAnimatorStateInfo(layerIndex).IsName(stateName);
            return result;
        }
        

        private void FixedUpdate()
        {
            rigi.position += deltaPos;
            //rigi.position += planerVec * Time.fixedDeltaTime; //consider gravity, costly
            rigi.velocity = new Vector3(planerVec.x, rigi.velocity.y, planerVec.z)+thrustVec; //y轴不能旋转
            thrustVec = Vector3.zero; //某些动画会带有推力，比如jump
            deltaPos = Vector3.zero;
        }
        
        //Receive Massage
        public void OnJumpEnter()
        {
            thrustVec = new Vector3(0, jumpVelocity, 0);
        }
        public void OnJumpUpdate()
        {
            thrustVec = model.transform.up * -anim.GetFloat("jumpVelocity");
        }

        public void OnJumpExit()
        {
        }

        public void IsGround()
        {
            anim.SetBool("isGround",true);
            
        }
        public void IsNotGround()
        {
            anim.SetBool("isGround",false);
        }

        public void OnGroundEnter()
        {
            //pi._InputEnable = true;
            //planerLook = false;
            col.material = frictionOne;
        }
        public void OnGroundExit()
        {
            //pi._InputEnable = false;
            //planerLook = true;
            col.material = frictionZero;
        }

        public void OnGroundUpdate()
        {
            canAttack = true;
        }

        public void OnRollEnter()
        {
            if(!canRollDistance)
            {
                pi._InputEnable = false;
                planerLook = true;
                planerVec = Vector3.zero;
            }
            thrustVec = 2f * model.transform.forward* movingSpeed * rollVelocity;
        }
        public void OnRollExit()
        {
            if (!canRollDistance)
            {
                pi._InputEnable = true;
                planerLook = false;
            }
        }
        public void OnRollUpdate()
        { 
            anim.SetBool("isGround",true);
            if (canRollDistance)
            {
                rigi.velocity = new Vector3(planerVec.x, rigi.velocity.y, planerVec.z)+thrustVec;
            }
        }

        public void OnJabUpdate()
        {
            thrustVec = model.transform.forward * anim.GetFloat("jabVelocity");
        }

        public void OnAttack1hAEnter()
        {
            pi._InputEnable = false;
            //anim.SetLayerWeight( 1,1.0f);
            lerpTarget = 1.0f;
        }
        public void  OnAttack1hAUpdate()
        {
            thrustVec = model.transform.forward * anim.GetFloat("attack1hAVelocity" );
            float currentWeight = anim.GetLayerWeight(anim.GetLayerIndex("attack"));
            currentWeight = Mathf.Lerp(currentWeight, lerpTarget, 0.1f);
            anim.SetLayerWeight(anim.GetLayerIndex("attack"),currentWeight);
        }
        public void  OnAttackIdleEnter()
        {
            pi._InputEnable = true;
            //anim.SetLayerWeight( 1,0f);
            lerpTarget = 0f;
        }

        public void OnAttackIdleUpdate()
        {
            anim.SetLayerWeight(anim.GetLayerIndex("attack"),Mathf.Lerp(anim.GetLayerWeight(anim.GetLayerIndex("attack")), lerpTarget, 0.1f));
        }

        public void OnUpdateRM(object _deltaPos)
        {if(CheckState("attack1hC","attack")||CheckState("attack1hD","attack"))
            deltaPos += (Vector3)_deltaPos;
        }
    }
}