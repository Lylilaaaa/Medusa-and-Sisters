using System;
using UnityEngine;

namespace UI_
{
    public class UIPlayerAnim : MonoBehaviour
    {
        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
            anim.SetBool("isStartHub",true);
        }
    }
}