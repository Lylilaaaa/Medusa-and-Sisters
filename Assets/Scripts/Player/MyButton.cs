namespace Player
{
    public class MyButton
    {
        public bool IsPressing = false;
        public bool OnPressed = false;
        public bool OnReleased = false;
        public bool IsExtending = false;

        private bool curState = false;
        private bool lastState = false;

        private MyTimer extTimer = new MyTimer(); 
        
        public void Tick(bool input)
        {
            extTimer.Tick(); 
            
            curState = input;
            IsPressing = curState;

            OnPressed = false;
            OnReleased = false;
            if (curState != lastState)
            {
                if (curState == true)
                {
                    OnPressed = true;
                }
                else
                {
                    OnReleased = true;
                    StartTimer(extTimer,0.15f);
                }
            }
            lastState = curState;
            if (extTimer.state == MyTimer.STATE.RUN)
            {
                IsExtending = true;
            }
            else
            {
                IsExtending = false;
            }
            
        }

        private void StartTimer(MyTimer timer, float duration)
        {
            timer.duration = duration;
            timer.Go();
        }
    }
}