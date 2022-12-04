using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using Camera;


public class WeaponController : MonoBehaviour
{
    public Collider collider;
    //private AudioSource audioSource;
    private Animator animator;
    private List<GameObject> targets = new List<GameObject>();

    public float NextDamage;


    private void OnDisable()
    {
        targets.Clear();
    }

    /// <summary>
    /// 此处传入攻击力，音效等资源
    /// </summary>
    /// <param name="audioSource"></param>
    public void init( Animator animator) {
        //this.audioSource = audioSource;
        this.animator = animator;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (targets.Contains(other.gameObject)) return;
        targets.Add(other.gameObject);
        if (other.tag == "enemy") {
            //打击效果
            FxController.instance.SpawnFx(4);
            //打击音效
            //audioSource.PlayOneShot(Resources.Load<AudioClip>("Audio/命中"));
            
            //屏幕震动
            StartCoroutine(CameraController.instance.Shake(0.1f,0.6f));
            
            //卡帧
            StartCoroutine(PauseFrame());
            //造成伤害
            other.gameObject.GetComponent<EnemyController>().getHurt(NextDamage);
            NextDamage = 0;
            //Debug.Log("hit");
        }
    }

    public void SettingNextDamage(float _nextDamage)
    {
        NextDamage = _nextDamage;
    }

    private IEnumerator PauseFrame() {
        //卡顿(降低动画速度)
        animator.speed = 0;

        //持续
        yield return new WaitForSeconds(0.2f);

        //恢复动画速度
        animator.speed = 1;
    }
    
    
}
