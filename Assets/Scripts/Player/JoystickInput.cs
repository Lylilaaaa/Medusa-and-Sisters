using System;
using UnityEngine;

namespace Player
{
    public class JoystickInput: IUserInput
    {
        [Header("===== Key Settings =====")]
        public string axisX = "axisX";
        public string axisY = "axisY";

        public string Run = "LB";
        public string Jump = "btnA";
        public string Roll = "btnB";
        public string Attack = "btnY";
        
        public string axisJright = "axis4";
        public string axisJup = "axis5";
        private void Update()
        {
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
            
            run = Input.GetButton(Run);
            
            bool newJump = Input.GetButton(Jump);
            if (newJump != lastJump && newJump == true)
            {
                jump = true;
            }
            else
            {
                jump = false;
            }
            lastJump = newJump;
        
            bool newAttack = Input.GetButton(Attack);
            if (newAttack != lastAttack && newAttack == true)
            {
                attack = true;
            }
            else
            {
                attack = false;
            }
            lastAttack = newAttack;
        
            bool newRoll = Input.GetButton(Roll);
            if (newRoll != lastroll && newRoll == true)
            {
                froll = true;
            }
            else
            {
                froll = false;
            }
            lastroll = newRoll;
        }

    }
}