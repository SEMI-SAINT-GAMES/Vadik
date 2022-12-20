using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEnemy : MonoBehaviour
{
    public int health = 3;
    
   
    public int killPoint;
    public AudioSource dieSound;
    public AudioSource damageSound;
    public Animator anim;
    public SniperControl sniperControl;
    





    private void Start()
    {

        Asign();
    }
    public void Asign()
    {
       
        sniperControl = GameObject.FindGameObjectWithTag("Player").GetComponent<SniperControl>();
        anim = GetComponent<Animator>();
        
    }

    public void TakeDamage(int damage)

    {
        health -= damage;
       

        if (health <= 0)
        {
            Die();
        }
        else
        {
           
            damageSound.Play();
        }
    }

   

    public void Die()
    {
        anim.SetTrigger("Die");
        
        dieSound.Play();
        Invoke("DestroyEnemy", 3f);
        if (sniperControl != null)
        {
            sniperControl.destrCount += 1;
        }

    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    
}
