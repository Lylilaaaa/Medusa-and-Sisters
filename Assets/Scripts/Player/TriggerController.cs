using Manager;
using UnityEngine;
using ScriptableObjectGen;
namespace Player
{
    public class TriggerController: MonoBehaviour
    {
        private Animator anim;
        public WeaponController weapon_Collider;
        public Avatars curAvatars;

        void Awake()
        {
            anim = GetComponent<Animator>();
            weapon_Collider.gameObject.SetActive(false);
            weapon_Collider.init(anim);
        }
        public void ResetTrigger(string triggerName)
        {
            anim.ResetTrigger(triggerName);
            //print("reset!");
        }
        
        /// <summary>
        /// 有效攻击帧开始
        /// </summary>
        public void StartHitNormal()
        {
            //音效
            //AudioSource.PlayOneShot(Resources.Load<AudioClip>("Audio/爪"));
            weapon_Collider.gameObject.SetActive(true);
            weapon_Collider.SettingNextDamage(curAvatars.damage);
            
        }
        
        public void StartHitCombo1B()
        {
            //音效
            //AudioSource.PlayOneShot(Resources.Load<AudioClip>("Audio/爪"));
            weapon_Collider.gameObject.SetActive(true);
            weapon_Collider.SettingNextDamage(curAvatars.combo1Damage[0]);
            
        }
        public void StartHitCombo1C()
        {
            //音效
            //AudioSource.PlayOneShot(Resources.Load<AudioClip>("Audio/爪"));
            weapon_Collider.gameObject.SetActive(true);
            weapon_Collider.SettingNextDamage(curAvatars.combo1Damage[1]);
            
        }
        
        public void StartHitCombo1Csub()
        {
            //音效
            //AudioSource.PlayOneShot(Resources.Load<AudioClip>("Audio/爪"));
            weapon_Collider.gameObject.SetActive(true);
            weapon_Collider.SettingNextDamage(curAvatars.combo1Damage[1]);
            
        }
        public void StartHitCombo1D()
        {
            //音效
            //AudioSource.PlayOneShot(Resources.Load<AudioClip>("Audio/爪"));

            weapon_Collider.gameObject.SetActive(true);
            weapon_Collider.SettingNextDamage(curAvatars.combo1Damage[2]);
            
        }
        

        /// <summary>
        /// 攻击帧结束
        /// </summary>
        public void StopHit()
        {
            //Debug.Log("disable weapon");
            weapon_Collider.gameObject.SetActive(false);
            FxController.instance.QuitFx(4);
        }

        public void StopHitsub()
        {
            weapon_Collider.gameObject.SetActive(false);
            FxController.instance.QuitFx(4);
        }

    }
}