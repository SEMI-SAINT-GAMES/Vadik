using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPatroolEdu : EnemyPatrool
{
    EducationManager educationManager;
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
        educationManager = GameObject.FindGameObjectWithTag("EduManager").GetComponent<EducationManager>();
        deathCount = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0 && deathCount > 0) 
        {
            Invoke("EduActiv", 4f);
            deathCount = 0;
            
        }
        if (angr && Vector2.Distance(transform.position, player.position) < 7)
        {
            if (startTimeBullet <= 0)
            {
                Instantiate(bullet, shotDirBullet.position, shotDirBullet.rotation);
                startTimeBullet = shotTimeBullet;
            }
            else
            {
                startTimeBullet -= Time.deltaTime;
            }
        }
        else if (angr)
        {
            Shoot();
        }
        
        Do();
    }
    void EduActiv()
    {
        //educationManager.Activate(9);
    }
    public void ExpIns()
    {
        float randX = Random.Range(-5, 5);
        float randY = Random.Range(-2, 2);
        Vector3 vect = transform.position + new Vector3(randX, randY, 0);
        Instantiate(expl, vect, Quaternion.identity);
       
    }
    
}
