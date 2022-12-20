using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrool : MonoBehaviour
{
    public float speed;
    public float PosOfPatr;
    public Transform point;
    public bool movRight;
    public Transform player;
    public float stoppingDistance;
    bool chil = false;
    public bool angr = false;
    public bool goBak = false;
    public GameObject ammo;
    public GameObject fire;
    public Transform shotDir;
    public Transform fireDir;
    public float timeShot;
    public float startTime;
    private bool flip;
    public Rigidbody2D rb;
    public GameObject Hero;
    private Control Hr;
    public AudioSource enShoot;
    public int health = 3;
    private Material matBlink;
    private Material matDef;
    private SpriteRenderer spriteRend;
    public int killPoint;
    public AudioSource[] dieSound;
    public bool isShooting;
    CoinManager coinManager;
    public EnemtAmmo enemtAmmo;
    public Animator anim;
    public bool alive;
    public GameObject battleManager;
    public GameObject deathCoin;
    public GameObject[] deathDrop;
    public GameObject blood;
   
    void Start()
    {


        Asign();

        
        
    }

    // Update is called once per frame
    void Update()
    {
        Do();
       
    }
    public void Asign()
    {
       
        alive = true;
        Hero = GameObject.FindGameObjectWithTag("Player");
        Hr = Hero.GetComponent<Control>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRend = GetComponent<SpriteRenderer>();
        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        
        matDef = spriteRend.material;
        rb = GetComponent<Rigidbody2D>();
        enemtAmmo = ammo.GetComponent<EnemtAmmo>();
        isShooting = false;
        anim = GetComponent<Animator>();
        Invoke("CheckTrans", 0.3f);
        coinManager = GameObject.FindGameObjectWithTag("CoinManager").GetComponent<CoinManager>();
    }
    public void CheckTrans()
    {
        if (transform.position.x < player.position.x)
        {
            Destroy(gameObject);
        }
    }
    public void Do()
    {
        if (alive == true)
        {
            if (Vector2.Distance(transform.position, point.position) < PosOfPatr && angr == false)
            {
                chil = true;
            }
            if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
            {
                angr = true;
                chil = false;
                goBak = false;
            }
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                goBak = true;
                angr = false;
            }
            if (chil == true || Hr.health <= 0)
            {
                chill();
            }
            else if (angr == true && Hr.health > 0)
            {
                angry();
            }
            else if (goBak == true)
            {
                GoBack();
            }
        }
            
        
        
    }
    void Flip()
    {
        movRight = !movRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
       
    }

    public void chill()
    {
        if (Vector2.Distance(transform.position, player.position) < 50)
        {
            if (transform.position.x > point.position.x + PosOfPatr)
            {
                if (movRight == true)
                {
                    Flip();
                }
            }
            else if (transform.position.x < point.position.x - PosOfPatr)
            {
                if (movRight == false)
                {
                    Flip();
                }
            }
            if (movRight)
            {
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);

            }
            else
            {
                transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            }

            angr = false;
        }
        
    }
    public void angry()
    {
        
        if (transform.position.x > player.position.x)
        {
            if (movRight == true)
            {
                Flip();
            }
        }
        else 
        {
            if (movRight == false)
            {
                Flip();
            }
        }
       
        
    }
    
   
    


    public void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }
    public void TakeDamage(int damage)

    {
        health -= damage;
        spriteRend.material = matBlink;
       
        if (health <= 0 && alive)
        {
            Die();
        }
        
        {
            Invoke("ResetMaterial", .2f);
        }
    }
    public void Shoot()
    {
        if (alive)
        {
            if (timeShot <= 0)
            {
                if (movRight == true)
                {

                    GameObject amm = Instantiate(ammo, shotDir.position, shotDir.rotation) as GameObject;
                    amm.GetComponent<EnemtAmmo>().movRight = true;
                    GameObject fir = Instantiate(fire, fireDir.position, shotDir.rotation) as GameObject;
                    //fir.transform.localScale *= -1;
                    fir.transform.rotation = Quaternion.Euler(0, 0, -90);

                }
                else if (movRight == false)
                {
                    //enemtAmmo.movRight = false;
                    GameObject amm = Instantiate(ammo, shotDir.position, shotDir.rotation) as GameObject;
                    amm.GetComponent<EnemtAmmo>().movRight = false;
                    GameObject fir = Instantiate(fire, fireDir.position, shotDir.rotation) as GameObject;
                    fir.transform.rotation = Quaternion.Euler(0, 0, 90);

                }
                timeShot = startTime;
                isShooting = true;
                enShoot.Play();
                Invoke("Recharge", 1f);
                Debug.Log("EnShoot");
            }
            else
            {

                timeShot -= Time.deltaTime;
            }
        }
    }

    void ResetMaterial()
    {
        spriteRend.material = matDef;
        
    }

    public void Die()
    {
        if (alive)
        {
            
            alive = false;
            ResetMaterial();
            anim.SetBool("Die", true);
            coinManager.CoinPlus(killPoint);
            int rand = Random.Range(0, dieSound.Length - 1);
            dieSound[rand].Play();
           
            
            if (battleManager != null)
            {
                battleManager.GetComponent<BattleLimit>().enCount += 1;
                
            }
            if (alive)
            {
                Instantiate(deathCoin, transform.position, Quaternion.identity);
            }

            Invoke("Death", 2f);
        }

    }
    public void Recharge()
    {
        isShooting = false;
    }
    public void Death()
    {
        Debug.Log("kkas");
        Instantiate(deathDrop[Random.Range(0, deathDrop.Length - 1)], transform.position, Quaternion.identity);
       
        gameObject.SetActive(false);

    }
    public void BloodIns(Vector3 pos, Quaternion rot)

    {
        Instantiate(blood, pos, rot);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(point.position.x + PosOfPatr, point.position.y), new Vector2(point.position.x - PosOfPatr, point.position.y));
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x - stoppingDistance, transform.position.y));
    }
    


}
