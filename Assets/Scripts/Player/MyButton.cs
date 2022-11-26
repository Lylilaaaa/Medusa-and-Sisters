namespace Player
{
    public class MyButton
    {
        public bool IsPressing = false;
        public bool OnPressed = false;
        public bool OnReleased = false;
        public bool IsExtending = false;
        public bool IsDelaying = false;
        
        private bool curState = false;
        private bool lastState = false;

        private MyTimer extTimer = new MyTimer(); 
        private MyTimer delayTimer = new MyTimer(); 
        
        public void Tick(bool input,float delayTime = 1.0f,float extendTime = 2.0f)
        {
            extTimer.Tick(); 
            delayTimer.Tick();
            
            curState = input;
            IsPressing = curState;

            OnPressed = false;
            OnReleased = false;
            IsExtending = false;
            IsDelaying = false;
            if (curState != lastState)
            {
                if (curState == true)
                {
                    OnPressed = true;
                    StartTimer(delayTimer,delayTime);
                }
                else
                {
                    OnReleased = true;
                    StartTimer(extTimer,extendTime);
                }
            }
            lastState = curState;
            if (extTimer.state == MyTimer.STATE.RUN)
            {
                IsExtending = true;
            }

            if (delayTimer.state == MyTimer.STATE.RUN)
            {
                IsDelaying = true;
            }

        }

        private void StartTimer(MyTimer timer, float duration)
        {
            timer.duration = duration;
            timer.Go();
        }
    }
}