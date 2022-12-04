using System;
using UnityEngine;

namespace Monster
{
    public class EnemyGroundDetect : MonoBehaviour
    {
        public bool isGrounded;
        public LayerMask ground;
        private void Update()
        {
            isGrounded = Physics.Raycast(transform.position, -transform.up, 0.5f, ground);
            if (isGrounded == true)
            {
                //print("is grounded mons");
            }
            else
            {
                //print("is not grounded mons");
            }
        }
    }
}