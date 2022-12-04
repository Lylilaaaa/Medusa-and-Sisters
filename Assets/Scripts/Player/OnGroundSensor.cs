using System;
using UnityEngine;

namespace Player
{
    public class OnGroundSensor : MonoBehaviour
    {
        public static OnGroundSensor instance;
        public CapsuleCollider capcol;
        public float offset;
        public LayerMask ground;
        public bool isStep;
        public GameObject Avatarmodel;
        public float forwardDis;
        public float upwardDis;
        
        private Vector3 point1;
        private Vector3 point2;
        private float radius;

        private void Awake()
        {
            radius = capcol.radius - 0.05f;
            instance = this;
        }
        
        private void FixedUpdate()
        {
            if(this.gameObject.tag == "monsterSensor") return;
            point1 = transform.position + transform.up * (radius - offset);
            point2 = transform.position + transform.up * (capcol.height - offset) - transform.up * radius;
            Collider[] outputCols = Physics.OverlapCapsule(point1, point1, radius, LayerMask.GetMask("Ground"));
            if (outputCols.Length != 0)
            {
                // foreach (var cols in outputCols)
                // {
                //     Debug.Log(cols);
                // }
                SendMessageUpwards("IsGround");
                //print("mons has grounded");
            }
            else
            {
                SendMessageUpwards("IsNotGround");
                //print("mons has not grounded");
            }

            forWardSensor();
        }

        public void forWardSensor()
        {
            isStep = Physics.Raycast(transform.position + Vector3.up * upwardDis, Avatarmodel.transform.forward, forwardDis, ground);
        }
    }
}