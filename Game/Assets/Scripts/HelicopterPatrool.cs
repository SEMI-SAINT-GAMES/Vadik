using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterPatrool : EnemyPatrool
{
    
    
    
   
    public float defSpeed;
    public float f;

    // Start is called before the first frame update
    void Start()
    {
        Asign();
        defSpeed = speed;
        GetComponent<Rigidbody2D>().simulated = false;
    }

    // Update is called once per frame
    void Update()
    {
        Do();
        Vector3 difference = player.position - transform.position;
        f = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        shotDir.rotation = Quaternion.Euler(0, 0, f );
       
        goBak = false;
    }

}

