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
        
        
        private void Awake()
        {
            pi = GetComponent<PlayerInput>();
            anim = model.GetComponent<Animator>();
            rigi = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            anim.SetFloat("forward",pi.Dmag * Mathf.Lerp(anim.GetFloat("forward"),((pi.run) ? 2.0f : 1.0f),0.5f)); //Smooth the process walk to run
            if (pi.jump)
            {
                anim.SetTrigger("jump");
            }
            if (pi.Dmag > 0.1f)
            {
                model.transform.forward = Vector3.Slerp(model.transform.forward, pi.Dvec, 0.05f); //Smooth truning around;
            }

            if (planerLook == false)
            {
                planerVec = pi.Dmag * model.transform.forward * movingSpeed * ((pi.run) ? runMultiplier : 1.0f);
            } //player input (both mag and direction)
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
            pi._InputEnable = false;
            Debug.Log("onjumpenter");
            planerLook = true;
            thrustVec = new Vector3(0, 5f, 0);
        }
        public void OnJumpExit()
        {
            pi._InputEnable = true;
            Debug.Log("onjumpexit");
            planerLook = false;
        }
    }
}