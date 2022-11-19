using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Player
{
    public class FSMClearSignals : StateMachineBehaviour
    {
        public string[] clearAtEnter;
        public string[] clearAtExit;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (var siganl in clearAtEnter)
            {
                animator.ResetTrigger(siganl);   
            }
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (var siganl in clearAtExit)
            {
                animator.ResetTrigger(siganl);   
            }
        }
    }
}