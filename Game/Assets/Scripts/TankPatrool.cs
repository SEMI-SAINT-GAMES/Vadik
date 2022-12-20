using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPatrool : EnemyPatrool
{

    private float startTimeBullet;
    public float shotTimeBullet;
    public Transform shotDirBullet;
    public GameObject bullet;
    public GameObject expl;
    int deathCount;
    public AudioSource bulletSound;

    // Start is called before the first frame update
    void Start()
    {
        Asign();
       
        deathCount = 1;
    }

    // Update is called once per frame
    void Update()
    {

       
        if (angr && Vector2.Distance(transform.position, player.position) < 7 && alive)
        {
            if (startTimeBullet <= 0)
            {
                Instantiate(bullet, shotDirBullet.position, shotDirBullet.rotation);
                startTimeBullet = shotTimeBullet;
                bulletSound.Play();
            }
            else
            {
                startTimeBullet -= Time.deltaTime;
            }
            
        }
        else if (angr && alive)
        {
            Shoot();
        }

        Do();
    }
    
    public void ExpIns()
    {
        float randX = Random.Range(-5, 5);
        float randY = Random.Range(-2, 2);
        Vector3 vect = transform.position + new Vector3(randX, randY, 0);
        Instantiate(expl, vect, Quaternion.identity);

    }
}
