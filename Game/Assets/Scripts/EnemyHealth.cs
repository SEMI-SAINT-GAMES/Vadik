using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public int health = 3;
    private Material matBlink;
    private Material matDef;
    private SpriteRenderer spriteRend;
    public int killPoint;
    public AudioSource dieSound;
   

   
  

    private void Start()
    {
       
        spriteRend = GetComponent<SpriteRenderer>();
        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDef = spriteRend.material;
    }

    public void TakeDamage(int damage)

    {
        health -= damage;
        spriteRend.material = matBlink;

        if (health <= 0)
        {
            Die();
        }
        else
        {
            Invoke("ResetMaterial", .2f);
        }
    }

    void ResetMaterial()
    {
        spriteRend.material = matDef;
    }

    void Die()
    {
        gameObject.SetActive(false);
        KillCount.kill += killPoint;
        dieSound.Play();
        
        

    }
    void Update()
    {
        
       
    }
   
}
