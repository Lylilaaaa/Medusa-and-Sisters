using System;
using UnityEngine;

namespace Player
{
    public class ActorController : MonoBehaviour
    {
        private PlayerInput pi;
        private Animator anim;
        private Rigidbody rigi;
        private Vector3 movingVec;

        public float movingSpeed;
        public GameObject model;

        private void Awake()
        {
            pi = GetComponent<PlayerInput>();
            anim = model.GetComponent<Animator>();
            rigi = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            anim.SetFloat("forward",pi.Dmag);
            if (pi.Dmag > 0.1f)
            {
                model.transform.forward = pi.Dvec;
            }

            movingVec = pi.Dmag * model.transform.forward * movingSpeed;
        }

        private void FixedUpdate()
        {
            rigi.position += movingVec * Time.fixedDeltaTime;
        }
    }
}