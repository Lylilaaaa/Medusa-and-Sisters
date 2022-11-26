using System;
using UnityEngine;

namespace Player
{
    public class JoystickInput: IUserInput
    {
        [Header("===== Key Settings =====")]
        public string axisX = "axisX";
        public string axisY = "axisY";
        private bool runTrigger;
        private MyButton BottonWalkRun = new MyButton();

        public string Other = "LB";
        public string Jump = "btnA";
        public string Roll = "btnB";
        public string Attack = "btnY";
        
        public string axisJright = "axis4";
        public string axisJup = "axis5";
        
        private MyButton BottonJump = new MyButton();
        private MyButton BottonRoll = new MyButton();
        private MyButton BottonAttack = new MyButton();
        
        private void Update()
        {
            BottonWalkRun.Tick(runTrigger);
            
            BottonJump.Tick(Input.GetButton(Jump));
            BottonRoll.Tick(Input.GetButton(Roll));
            BottonAttack.Tick(Input.GetButton(Attack));
            
            Jup = -Input.GetAxis(axisJup);
            Jright = Input.GetAxis(axisJright);
            
            targetDup = Input.GetAxis(axisY);
            targetDright = Input.GetAxis(axisX);

            if (_InputEnable == false)
            {
                targetDup = 0;
                targetDright = 0;
            }

            Dup = Mathf.SmoothDamp(Dup, targetDup, ref velocityDup, 0.1f);
            Dright = Mathf.SmoothDamp(Dright, targetDright, ref velocityDright, 0.1f);
            
            Vector2 tempDAxis = SqToCircle(new Vector2(Dup, Dright));
            float Dup2 = tempDAxis.x;
            float Dright2 = tempDAxis.y;
        
            Dmag = Mathf.Sqrt((Dup2 * Dup2) + (Dright2 * Dright2));
            Dvec = Dup2 * transform.forward + Dright2 * transform.right;
            
            runTrigger = false;
            if (Dmag >= 0.5)
            {
                runTrigger = true;
            }
            
            //加入了Botton的抽象类之后按键输入系统：
            run = BottonWalkRun.IsPressing && !BottonWalkRun.IsDelaying;

            attack = BottonAttack.OnPressed;
            froll = BottonRoll.OnPressed;
            jump = BottonJump.OnPressed;
            
            //原始的输入系统：
            //run = Input.GetButton(Run);
            
            // bool newJump = Input.GetButton(Jump);
            // if (newJump != lastJump && newJump == true)
            // {
            //     jump = true;
            // }
            // else
            // {
            //     jump = false;
            // }
            // lastJump = newJump;
    

        }

    }
}