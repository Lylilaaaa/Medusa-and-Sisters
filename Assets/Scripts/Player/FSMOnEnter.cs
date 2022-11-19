using UnityEngine;

namespace Player
{
    public class FSMOnEnter : StateMachineBehaviour
    {
        public string[] onEnterMessages;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (var msg in onEnterMessages)
            {
                animator.gameObject.SendMessageUpwards(msg);   
            }
        }
    }
}