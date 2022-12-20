using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleEnemy : MonoBehaviour
{
    public int health = 100;
    public GameObject smoke;
    public GameObject explosion;
    public GameObject empty;
    public float timer;
    float timerStart;
    public Transform shotDir;
    public GameObject weapon;
    public GameObject ammo;
    public bool shooting = false;
    public bool right;
    public bool isLast;
    public int currentEnemy;
    public AudioSource shootSound;
    TigrVehicleDiagonal tigrVehicleDiagonal;
    public GameObject fire;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ShotOn", 4f);
        tigrVehicleDiagonal = GetComponentInParent<TigrVehicleDiagonal>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shooting && tigrVehicleDiagonal.isDoing)
        {
            Shoot();
        }
    }
    public void TakeDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            if (health == 30)
            {
                smoke.SetActive(true);
            }
        }
        else
        {
            
            Die();
           
        }
    }
    void ShotOn()
    {
        shooting = true;
    }
    void Shoot()
    {
        if (timerStart <= 0)
        {
            GameObject am = Instantiate(ammo, shotDir.position, shotDir.rotation) as GameObject;
            if(right)
            {
                am.GetComponent<VehicleAmmoEnemy>().movRight = false;
            }
            Instantiate(fire, shotDir.position, shotDir.rotation, this.transform);
            timerStart = timer;
            shootSound.Play();
            //weapon.transform.rotation = Quaternion.Euler(weapon.transform.rotation.x, weapon.transform.rotation.y, weapon.transform.rotation.z + Random.Range(-2, 2));
        }
        else
        {
            timerStart -= Time.deltaTime;
        }
    }
    public void Die()
    {
        Instantiate(explosion, transform.position + new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0), transform.rotation);
        Instantiate(explosion, transform.position + new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0), transform.rotation);
        Instantiate(explosion, transform.position + new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0), transform.rotation);
        Instantiate(empty, transform.position, transform.rotation);
        if (!isLast)
        {
            Invoke("NextEnemy", 1f);
        }
        tigrVehicleDiagonal.enemyCount += 1;
        gameObject.SetActive(false);
    }
    public void NextEnemy()
    {

        tigrVehicleDiagonal.EnemyIns(currentEnemy + 1);
    }
    
}
