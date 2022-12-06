using System.Collections;
using UnityEngine;

namespace Monster
{
    public class EnemyDie : MonoBehaviour
    {
        public Animator animator;
        public Renderer skinnedMeshRenderer;
        public ParticleSystem particles;
        public float Duration = 1f;
        public float waitBeforeDissolve = 1f;
        public bool startDieAnim;

        private bool press;
        private float number;
        private Material[] dissolveMaterials;
        public GameObject TriggerAttack;

        void Start()
        {
            startDieAnim = false;
            if (particles != null)
            {
                particles.Stop();
                particles.gameObject.SetActive(false);
            }

            if (skinnedMeshRenderer != null)
            {
                dissolveMaterials = skinnedMeshRenderer.materials;
            }
        }

        void Update()
        {
            if (startDieAnim)
            {
                startDieAnim = false;
                StartCoroutine(PlayerDeath());

                if (animator != null)
                {
                    animator.SetTrigger("dead");
                }
            }

            if (press == true)
            {
                for (int i = 0; i < dissolveMaterials.Length; i++)
                {
                    number += Time.deltaTime / Duration;
                    dissolveMaterials[i].SetFloat("Dissolve", number);
                }
            }
        }
        
        public void HitStart()
        {
            TriggerAttack.SetActive(true);
        }

        public void HitEnd()
        {
            TriggerAttack.SetActive(false);
        }

        IEnumerator PlayerDeath()
        {
            yield return new WaitForSeconds(waitBeforeDissolve);
            press = true;
            if (particles != null)
            {
                particles.gameObject.SetActive(true);
                particles.Play();
            }
            
            Destroy(gameObject, 3f);
        }
    }
}