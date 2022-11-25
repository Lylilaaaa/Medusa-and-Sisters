using UnityEngine;
namespace Player
{
    public class TriggerController: MonoBehaviour
    {
        private Animator anim;

        void Awake()
        {
            anim = GetComponent<Animator>();
        }
        public void ResetTrigger(string triggerName)
        {
            anim.ResetTrigger(triggerName);
            print("reset!");
        }
    }
}