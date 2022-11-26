using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Player
{
    public class KeyboardInput : IUserInput
    {
        [Header("===== Key Settings =====")]
        public string keyUp = "w";
        public string keyDown = "s";
        public string keyRight = "d";
        public string keyLeft = "a";
    
        public string KeyA;
        public string KeyB;
        public string KeyC;
        public string KeyD;
    
        public string KeyJUp;
        public string KeyJDown;
        public string KeyJRight;
        public string KeyJLeft;
    
        void Update()
        {
            Jup = (Input.GetKey(KeyJUp) ? 1.0f : 0f) - (Input.GetKey(KeyJDown) ? 1.0f : 0f);
            Jright = (Input.GetKey(KeyJRight) ? 1.0f : 0f) - (Input.GetKey(KeyJLeft) ? 1.0f : 0f);
            
            //移动处理
            targetDup = ((Input.GetKey(keyUp) ? 1.0f : 0) - (Input.GetKey(keyDown) ? 1.0f : 0));
            targetDright = ((Input.GetKey(keyRight) ? 1.0f : 0) - (Input.GetKey(keyLeft) ? 1.0f : 0));

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
            
            
            // ===== due with signal types ===== //
            
            //buttom按住相关信号：跑步
            run = Input.GetKey(KeyA);

            //trigger相关信号：跳跃/翻滚/攻击
            bool newJump = Input.GetKey(KeyB);
            if (newJump != lastJump && newJump == true)
            {
                jump = true;
            }
            else
            {
                jump = false;
            }
            lastJump = newJump;
        
            bool newAttack = Input.GetKey(KeyD);
            if (newAttack != lastAttack && newAttack == true)
            {
                attack = true;
            }
            else
            {
                attack = false;
            }
            lastAttack = newAttack;
        
            bool newRoll = Input.GetKey(KeyC);
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
