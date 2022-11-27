using UnityEngine;

namespace Player
{
    public abstract class IUserInput: MonoBehaviour
    {
        [Header("===== Output Signals =====")]
        public float Dup;
        public float Dright;
        public float Dmag;
        public Vector3 Dvec;
        public float Jup;
        public float Jright;

        //1. pressing signal
        public bool run;
    
        //2. trigger signal
        public bool jump;

        public bool attack;

        public bool froll;
        
        public bool Onlocked;
        public bool Unlocked;
        public bool Onlocking;

        //3. double trigger

        [Header("===== Others =====")]
        public bool _InputEnable = true;

        protected float targetDup;
        protected float targetDright;
        protected float velocityDup;
        protected float velocityDright;

        protected Vector2 SqToCircle(Vector2 input)
        {
            Vector2 output = Vector2.zero;

            output.x = input.x * Mathf.Sqrt(1 - (input.y * input.y) / 2.0f);
            output.y = input.y * Mathf.Sqrt(1 - (input.x * input.x) / 2.0f);

            return output;
        }
    }
    
}