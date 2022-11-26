using System;
using Player;
using UnityEngine;

namespace Collected
{
    public class RunningAbility : MonoBehaviour
    {
        private ActorController ac;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                ac = other.gameObject.GetComponent<ActorController>();
                ac.canRun = true;
            }
        }
    }
}