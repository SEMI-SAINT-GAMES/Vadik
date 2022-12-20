using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class javAmmo : AK47Ammo
{



    public int grenadeDamage;
    

    // Start is called before the first frame update
    void Start()
    {
        Asign();
       
        

    }

    // Update is called once per frame
    void Update()
    {
        Direct();
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        EnemyPatrool enemy = other.gameObject.GetComponent<EnemyPatrool>();
        if (enemy != null)

        {
            enemy.TakeDamage(grenadeDamage);
        }
        BossHealth bossHealth = other.gameObject.GetComponent<BossHealth>();
        if (bossHealth != null)
        {
            bossHealth.TakeDamage(grenadeDamage);
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);

        


    }
}