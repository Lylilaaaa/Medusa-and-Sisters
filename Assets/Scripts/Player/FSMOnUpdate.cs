using UnityEngine;
namespace Player
{
    public class FSMOnUpdate: StateMachineBehaviour
    {
        public string[] onUpdateMessages;
        
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (var msg in onUpdateMessages)
            {
                animator.gameObject.SendMessageUpwards(msg);
            }
        }
    }
}