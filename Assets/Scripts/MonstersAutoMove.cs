using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersAutoMove : EnemyController
{
    private Transform target;
    private int wavepointsIndex=0;
    public GameObject SpawnPoints;
    public static Transform[]points;// 挂载此怪物自动走动路径
    // Start is called before the first frame update
    void Awake()
    {
        Init();
        points=new Transform[SpawnPoints.transform.childCount];//生成路径点列表
        
        for (int i=0;i<points.Length;i++)
        {
            points[i]=SpawnPoints.transform.GetChild(i);
          
        }
        target=points[0];
     
    }

    // Update is called once per frame
    void Update()
    {
        
        AutoMove();
        

    }
    void GetNextWaypoint()
    {
        Debug.Log(wavepointsIndex);
        if(wavepointsIndex>=points.Length-1)
        {
            wavepointsIndex = 0;
        }
        wavepointsIndex+=1;
        target=points[wavepointsIndex];
    }
    
    void AutoMove()
    {
        if (!MonsterType.isChasing)
        {
            anim.SetBool("move",true);
           
            //move toward player 
            Vector3 des = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
           
            Vector3 tempForward = target.transform.position - model.transform.position;
            tempForward.y = 0;
            transform.position = Vector3.MoveTowards(transform.position, des, MonsterType.movingSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position,target.position)<=2f)
            {
                GetNextWaypoint();
            }
            //rotate facing
            model.transform.forward = tempForward;
            
            
        } 
    }
}
