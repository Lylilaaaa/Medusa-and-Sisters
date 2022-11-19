using System;
using UnityEngine;

namespace Player
{
    public class OnGroundSensor : MonoBehaviour
    {
        public CapsuleCollider capcol;
        public float offset = 0.2f;
        
        private Vector3 point1;
        private Vector3 point2;
        private float radius;

        private void Awake()
        {
            radius = capcol.radius - 0.05f;

        }

        private void FixedUpdate()
        {
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
            }
            else
            {
                SendMessageUpwards("IsNotGround");
            }
        }
    }
}