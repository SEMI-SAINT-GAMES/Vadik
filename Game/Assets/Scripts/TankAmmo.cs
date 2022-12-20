using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAmmo : AK47Ammo
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyAmmo", destroyTime);
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
            enemy.TakeDamage(damage[currentAmmo]);
        }
        Destroy(gameObject);
        
            Instantiate(explosion, transform.position, transform.rotation);
        
    }

}
