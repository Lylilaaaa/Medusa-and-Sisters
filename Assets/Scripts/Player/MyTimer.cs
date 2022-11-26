using UnityEngine;

namespace Player
{
    public class MyTimer
    {
        public enum STATE
        {
            IDLE,
            RUN,
            FINISHED
        }

        public STATE state;
        
        public float duration = 1f;
        private float elapsedTime;

        public void Tick()
        {
            switch (state)
            {
                case STATE.IDLE:
                    
                    break;
                case STATE.RUN:
                    elapsedTime += Time.deltaTime;
                    if (elapsedTime >= duration)
                    {
                        state = STATE.FINISHED;
                    }
                    break;
                case STATE.FINISHED:
                    break;
                default:
                    Debug.Log("MyTimer error");
                    break;
            }
        }

        public void Go()
        {
            elapsedTime = 0;
            state = STATE.RUN;
        }
    }
}