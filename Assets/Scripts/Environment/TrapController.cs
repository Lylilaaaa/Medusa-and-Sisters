using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public float damage;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            ActorController.instance.getHurt(damage);
        }
    }
}
