using System;
using UnityEngine;

namespace Monster
{
    public class EnemyGroundDetect : MonoBehaviour
    {
        public bool isGrounded;
        public bool isStep;
        public LayerMask ground;
        public float forwardDis;
        public float upwardDis;
        public GameObject Avatarmodel;
        private void Update()
        {
            //isGrounded = Physics.Raycast(transform.position, -transform.up, 0.5f, ground);
            //isStep = Physics.Raycast(transform.position + Vector3.up * upwardDis, Avatarmodel.transform.forward, forwardDis, ground);
        }
    }
}