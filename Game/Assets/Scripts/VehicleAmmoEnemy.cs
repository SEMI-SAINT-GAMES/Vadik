using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleAmmoEnemy : EnemtAmmo
{
    // Start is called before the first frame update
    void Start()
    {
        Asign();
    }

    // Update is called once per frame
    void Update()
    {
        Do();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TigrVehicleDiagonal tigr = collision.GetComponent<TigrVehicleDiagonal>();
        if (tigr != null)
        {
            tigr.TakeDamage(uron);
            Instantiate(blood, transform.position, Quaternion.identity, tigr.gameObject.transform);
        }
    }
}
