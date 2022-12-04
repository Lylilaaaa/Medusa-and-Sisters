using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public bool Death;    
    public float Cooldown;
    public GameObject[] Enemy;

    private int number;
    private float Timer;
    private bool IsPressed;
    private GameObject currentInstance;
    

    void Start()
    {
        Dtimer();
        this.gameObject.tag = "Enemy";
        ChangeCurrent(0);
    }

    
    void Update()
    {
        if (Death == true)
        {
            Timer += Time.deltaTime;
        }
        
        if (Timer >= Cooldown)
        {
            Enemy[number].transform.position = transform.position;
            currentInstance = Instantiate(Enemy[number]);
            Dtimer();
        }
    }

    void OnGUI()
    {
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            IsPressed = false;            
        }

        if (!IsPressed && Input.GetKeyDown(KeyCode.A))
        {
            IsPressed = true;
            ChangeCurrent(-1);
            Dtimer();
        }

        if (!IsPressed && Input.GetKeyDown(KeyCode.D))
        {
            IsPressed = true;
            ChangeCurrent(+1);
            Dtimer();
        }
    }

    void ChangeCurrent(int delta)
    {
        number += delta;
        if (number > Enemy.Length - 1)
            number = 0;
        else if (number < 0)
            number = Enemy.Length - 1;

        if (currentInstance != null)
        {
            Destroy(currentInstance);
        }
        currentInstance = Instantiate(Enemy[number]);
    }

    void Dtimer()
    {
        Death = false;
        Timer = 0;
    }


}//class























