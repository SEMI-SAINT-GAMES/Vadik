using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47Ammo : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    public int[] damage;
    public int currentAmmo;
    public GameObject blood;
    public GameObject explosion;
    public bool isRight;
    public Sprite[] Ammos;

    // Start is called before the first frame update
    void Start()
    {
        Asign();
        GetComponent<SpriteRenderer>().sprite = Ammos[currentAmmo];


    }
    public void Asign()
    {
       
        Invoke("DestroyAmmo", destroyTime);
        currentAmmo = PlayerPrefs.GetInt("CurrentWeapon");
        
    }
    // Update is called once per frame
    void Update()
    {
        Direct();
    }
    public void Direct()
    {
        
        if (isRight)
        {

            transform.Translate(Vector2.right * speed * Time.deltaTime);
            
           
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
           


        }
    }
    void DestroyAmmo()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        EnemyPatrool enemy = other.gameObject.GetComponent<EnemyPatrool>();
        
        if (enemy != null)

        {
            enemy.TakeDamage(damage[currentAmmo]);
            if (isRight)
            {
                enemy.BloodIns(transform.position, Quaternion.identity);
            }
            else
            {
                enemy.BloodIns(transform.position, Quaternion.Euler(-180, 0, 0));
            }

            Debug.Log("torso");
        }
        
        
        BossHealth bossHealth = other.gameObject.GetComponent<BossHealth>();
        if (bossHealth != null && bossHealth.isAttack == false) 
        {
            bossHealth.TakeDamage(damage[currentAmmo]);
            if (isRight)
            {
                Instantiate(blood, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(blood, transform.position, Quaternion.Euler(0, 0, 180));
            }
        }

        Destroy(gameObject);

    }
    
}
