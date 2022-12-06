using System;
using UnityEngine;

namespace Shadows
{
    public class ShadowTrigger : MonoBehaviour
    {
        public GameObject ShadowHandler;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                ShadowHandler.SetActive(true);
            }
        }
    }
}