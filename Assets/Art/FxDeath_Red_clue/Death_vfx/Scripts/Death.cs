using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Animator animator;
    public Renderer skinnedMeshRenderer;   
    public ParticleSystem particles;
    public float Duration = 1f;
    public float waitBeforeDissolve = 1f;
    
    private bool press;
    private float number;
    private Material[] dissolveMaterials;

    


    void Start()
    {
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
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine(PlayerDeath());
 
            if (animator != null)
            {
                animator.SetTrigger("Die");
            }            
        }

        if (press == true)
        {
            for(int i = 0; i < dissolveMaterials.Length; i++)
            {
                number += Time.deltaTime / Duration;
                dissolveMaterials[i].SetFloat("Dissolve", number);
            }            
        }
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
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<Respawn>().Death = true;
        Destroy(gameObject, 3f);
    }










}//class
