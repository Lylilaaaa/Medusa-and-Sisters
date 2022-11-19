using UnityEngine;
namespace Player
{
    public class FSMOnExit: StateMachineBehaviour
    {
        public string[] onExitMessages;

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (var msg in onExitMessages)
            {
                animator.gameObject.SendMessageUpwards(msg);
            }
        }
    }
}