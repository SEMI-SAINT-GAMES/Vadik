using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrkRegPatrool : EnemyPatrool
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
        if (alive && angr)
        {
            anim.SetBool("Angry", true);
        }
        if (angr && timeShot <= 0)
        {
            anim.SetTrigger("Shoot");
        }
        if (!angr)
        {
            anim.SetBool("Angry", false);
        }
        if(angr)
        {
            Shoot();
        }
    }
}
