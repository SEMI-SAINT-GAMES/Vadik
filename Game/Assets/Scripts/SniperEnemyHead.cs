using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEnemyHead : MonoBehaviour
{
    public AudioSource dieSound;
    
    private SniperEnemy sniperEnemy;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        sniperEnemy = GetComponentInParent<SniperEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Die()
    {
        sniperEnemy.TakeDamage(damage);
        
        dieSound.Play();
    }
}
