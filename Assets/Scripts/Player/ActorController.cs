using System;
using UnityEngine;

namespace Player
{
    public class ActorController : MonoBehaviour
    {

        private PlayerInput pi;
        private Animator anim;
        private Rigidbody rigi;
        public GameObject model;
        
        [SerializeField]
        private Vector3 planerVec; //important!!
        private bool planerLook ;
        private Vector3 thrustVec;

        [Header(" ===== Controller Setting ===== ")]
        public float movingSpeed;
        private float runMultiplier = 2.5f;
        public float jumpVelocity;
        public float rollVelocity;
        
        private void Awake()
        {
            pi = GetComponent<PlayerInput>();
            anim = model.GetComponent<Animator>();
            rigi = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            anim.SetFloat("forward",pi.Dmag * Mathf.Lerp(anim.GetFloat("forward"),((pi.run) ? 2.0f : 1.0f),0.5f)); //Smooth the process walk to run
            if (rigi.velocity.magnitude > 5f)
            {
                anim.SetTrigger("roll");
            }
            if (pi.jump)
            {
                anim.SetTrigger("jump");
            }
            if (pi.froll)
            {
                anim.SetTrigger("forceroll");
            }
            if (pi.Dmag > 0.1f)
            {
                model.transform.forward = Vector3.Slerp(model.transform.forward, pi.Dvec, 0.05f); //Smooth truning around;
            }
            if (planerLook == false)
            {
                planerVec = pi.Dmag * model.transform.forward * movingSpeed * ((pi.run) ? runMultiplier : 1.0f);//player input (both mag and direction)
            } 
        }

        private void FixedUpdate()
        {
            //rigi.position += planerVec * Time.fixedDeltaTime; //consider gravity, costly
            rigi.velocity = new Vector3(planerVec.x, rigi.velocity.y, planerVec.z)+thrustVec;
            thrustVec = Vector3.zero;
        }
        
        //Receive Massage
        public void OnJumpEnter()
        {
            thrustVec = new Vector3(0, jumpVelocity, 0);
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
            pi._InputEnable = true;
            planerLook = false;
        }
        public void OnGroundExit()
        {
            pi._InputEnable = false;
            planerLook = true;
        }

        public void OnRollEnter()
        {
            pi._InputEnable = false;
            planerLook = true;
            planerVec = 2f * model.transform.forward* movingSpeed * rollVelocity;
        }
        public void OnRollExit()
        {
            pi._InputEnable = true;
            planerLook = false;
        }
        public void OnRollUpdate()
        { 
            anim.SetBool("isGround",true);
        }
    }
}