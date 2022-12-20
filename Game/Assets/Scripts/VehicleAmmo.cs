using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleAmmo : AK47Ammo
{
    
    // Start is called before the first frame update
    void Start()
    {
        Asign();
        currentAmmo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Direct();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        VehicleEnemy vehicleEnemy = collision.GetComponent<VehicleEnemy>();
        if (vehicleEnemy != null)
        {
            vehicleEnemy.TakeDamage(damage[0]);
            
            Instantiate(blood, transform.position, Quaternion.Euler(0,90,0), vehicleEnemy.gameObject.transform);
            Destroy(gameObject);
            
        }
    }
}
