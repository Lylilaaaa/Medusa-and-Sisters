using System;
using UnityEngine;
namespace Player
{
    public class RootMotionController: MonoBehaviour
    {
        private Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        private void OnAnimatorMove()
        {
            SendMessageUpwards("OnUpdateRM",(object)anim.deltaPosition);
        }
    }
}