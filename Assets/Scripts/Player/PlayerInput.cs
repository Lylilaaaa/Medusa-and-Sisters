using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string keyUp = "w";
    public string keyDown = "s";
    public string keyRight = "d";
    public string keyLeft = "a";  
    
    public float Dup;
    public float Dright;
    public float Dmag;
    public Vector3 Dvec;

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
        Dmag = Mathf.Sqrt((Dup * Dup) + (Dright * Dright));
        Dvec = Dup * transform.forward + Dright * transform.right;
    }
}
