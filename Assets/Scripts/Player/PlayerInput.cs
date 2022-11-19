using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerInput : MonoBehaviour
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
    
    [Header("===== Output Signals =====")]
    public float Dup;
    public float Dright;
    public float Dmag;
    public Vector3 Dvec;

    //1. pressing signal
    public bool run;
    
    //2. trigger signal
    public bool jump;
    private bool lastJump;
    
    //3. double trigger

    [Header("===== Others =====")]
    public bool _InputEnable = true;

    private float targetDup;
    private float targetDright;
    private float velocityDup;
    private float velocityDright;
    

    // Update is called once per frame
    void Update()
    {
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
        
        //due with signal types
        run = Input.GetKey(KeyA);

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
    }

    private Vector2 SqToCircle(Vector2 input)
    {
        Vector2 output =  Vector2.zero;

        output.x = input.x * Mathf.Sqrt(1 - (input.y * input.y) / 2.0f);
        output.y = input.y * Mathf.Sqrt(1 - (input.x * input.x) / 2.0f);

        return output;
    }
}
