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
        private bool runTrigger;
        private MyButton BottonWalkRun = new MyButton();
    
        public string KeyLock ="left shift";
        public string KeyJump = "k";
        public string KeyRoll = "l";
        public string KeyAttack = "j";
        
        public string KeyJUp = "up";
        public string KeyJDown = "down";
        public string KeyJRight = "right";
        public string KeyJLeft = "left";
        

        [Header("===== Mouse Settings =====")]
        public bool mouseEnable = true;
        public float mouseSensitivityX = 1.0f;
        public float mouseSensitivityY = 1.0f;

        public string mouseJump = "f";
        public string mouseRoll = "mouse 1";
        public string mouseAttack = "mouse 0";
        
        private MyButton BottonKeyJump = new MyButton();
        private MyButton BottonKeyRoll = new MyButton();
        private MyButton BottonKeyAttack = new MyButton();
        private MyButton BottonKeyLock = new MyButton();
        
        private MyButton BottonMouseJump = new MyButton();
        private MyButton BottonMouseRoll = new MyButton();
        private MyButton BottonMouseAttack = new MyButton();

        void Update()
        {
            BottonWalkRun.Tick(runTrigger);

            BottonKeyLock.Tick(Input.GetKey(KeyLock));
            BottonKeyJump.Tick(Input.GetKey(KeyJump));
            BottonKeyRoll.Tick(Input.GetKey(KeyRoll));
            BottonKeyAttack.Tick(Input.GetKey(KeyAttack));
            BottonMouseJump.Tick(Input.GetKey(mouseJump));
            BottonMouseRoll.Tick(Input.GetKey(mouseRoll));
            BottonMouseAttack.Tick(Input.GetKey(mouseAttack));

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                esc = true;
            }
            else
            {
                esc = false;
            }
            
            if (mouseEnable)
            {
                Jup = Input.GetAxis("Mouse Y") * 2.5f * mouseSensitivityY;
                Jright = Input.GetAxis("Mouse X") * 3.0f * mouseSensitivityX;
            }
            else
            {
                Jup = (Input.GetKey(KeyJUp) ? 1.0f : 0f) - (Input.GetKey(KeyJDown) ? 1.0f : 0f);
                Jright = (Input.GetKey(KeyJRight) ? 1.0f : 0f) - (Input.GetKey(KeyJLeft) ? 1.0f : 0f);
            }

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
            
            runTrigger = false;
            if (Dmag >= 0.5)
            {
                runTrigger = true;
            }
            
            // ===== due with signal types ===== //
            
            //buttom按住相关信号：跑步
            run = BottonWalkRun.IsPressing && !BottonWalkRun.IsDelaying;
            
            Onlocked = BottonKeyLock.OnPressed;
            Onlocking = BottonKeyLock.IsPressing;
            Unlocked = BottonKeyLock.OnReleased;

            jump = BottonMouseJump.OnPressed || BottonKeyJump.OnPressed;
            attack = BottonMouseAttack.OnPressed || BottonKeyAttack.OnPressed;
            froll = BottonMouseRoll.OnPressed || BottonKeyRoll.OnPressed;
            
            //trigger相关信号：跳跃/翻滚/攻击
            // bool newJump = Input.GetKey(KeyJump[0]) || Input.GetKey(KeyJump[1]);
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
