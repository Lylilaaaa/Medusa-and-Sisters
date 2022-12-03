using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Collider collider;
    private AudioSource audioSource;
    private Animator animator;
    private List<GameObject> targets = new List<GameObject>();


    private void OnDisable()
    {
        targets.Clear();
    }

    /// <summary>
    /// 此处传入攻击力，音效等资源
    /// </summary>
    /// <param name="audioSource"></param>
    public void init(AudioSource audioSource, Animator animator) {
        this.audioSource = audioSource;
        this.animator = animator;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (targets.Contains(other.gameObject)) return;
        targets.Add(other.gameObject);
        if (other.tag == "enemy") {
            //打击效果
            GameObject.Instantiate(Resources.Load("刀光"), other.bounds.ClosestPoint(transform.position), Quaternion.identity, null);
            //打击音效
            audioSource.PlayOneShot(Resources.Load<AudioClip>("Audio/命中"));
            //屏幕震动
            //Camera_control.instance.Shake();
            //卡帧
            StartCoroutine(PauseFrame());
            //造成伤害
            Debug.Log("hit");
        }
    }

    private IEnumerator PauseFrame() {
        //卡顿(降低动画速度)
        animator.speed = 0;

        //持续
        yield return new WaitForSeconds(0.1f);

        //恢复动画速度
        animator.speed = 1;
    }
}
