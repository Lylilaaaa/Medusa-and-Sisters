using System;
using UnityEngine;

namespace InputTest
{
    public class TestJoy: MonoBehaviour
    {
        private void Update()
        {
            // print("Dright "+Input.GetAxis("Dright"));
            // print("Dup "+Input.GetAxis("Dup"));
            // print("Jright "+Input.GetAxis("Jright"));
            // print("Jup "+Input.GetAxis("Jup"));
            print("btnA: "+Input.GetButton("btnA"));
            print("btnB: "+Input.GetButton("btnB"));
            print("btnX: "+Input.GetButton("btnX"));
            print("btnY: "+Input.GetButton("btnY"));
            // print("RB: "+Input.GetButtonDown("RB"));
            // print("LB: "+Input.GetButtonDown("LB"));
            // print("padH "+Input.GetAxis("padH"));
            // print("padV "+Input.GetAxis("padV"));
            print("Bumper "+Input.GetAxis("Bumper"));
        }
    }
}