using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinAmmo : AK47Ammo
{
    public bool isDoing = false;
    bool alreadyRight = false;
    public int grenadeDamage;
    // Start is called before the first frame update
    void Start()
    {
        Asign();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isDoing)
        {
            Direct();
            speed += 3.5f * Time.deltaTime;
        }
    }
    public void Go()
    {
        isDoing = true;
        Debug.Log("do");
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
