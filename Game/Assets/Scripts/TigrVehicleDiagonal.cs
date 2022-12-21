using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TigrVehicleDiagonal : MovGroundDiagonal
{
    public bool isDoing;
    Control control;
    bool isEnd;
    public float timerStart;
    public float timer;
    public float[] eventTimes;
    public GameObject[] enemy;
    public Transform[] enemyDir;
    public int health;
    public Image healthBar;
    public GameObject explosion;
    public VehicleEnemy vehicleEnemy;
    public int enemyCount = 0;
    public int allEmemys = 3;
    bool isDial;
    public AudioSource engineSound;
    public AudioSource stopSound;
    // Start is called before the first frame update
    void Start()
    {
        Asign();
        control = GameObject.FindGameObjectWithTag("Player").GetComponent<Control>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDoing)
        {
            Do();
            Quaternion q = Quaternion.Euler(0, 0, -myPath.angleBetween);
            transform.rotation = Quaternion.Lerp(transform.rotation, q, rotationSpeed * Time.deltaTime);
            if (!isEnd)
            {
                timerStart -= Time.deltaTime;
                if (timerStart <= 0)
                {
                    if (enemyCount >= allEmemys)
                    {
                        isEnd = true;
                        control.OutOfCar(false);
                        GetComponent<BoxCollider2D>().enabled = false;
                        isDoing = false;
                        GetComponentInChildren<VehicleWeapon>().shotSoundTigr.Stop();
                    }
                    else
                    {

                        health = 0;
                        Die();
                        
                    }
                }
                if (enemyCount >= allEmemys && !isDial)
                {
                    GetComponent<EndDialogTigr>().Invoke("GetDialog", 1f);
                    isDial = true;
                }
            }
            healthBar.fillAmount = health * 0.01f;
            
        }
        
       
    }
    public void TimerOn()
    {
        timerStart = timer;
        Invoke("StartIns", 3f);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ld");
    }
    public void EnemyIns(int current)
    {
        enemy[current].SetActive(true);
        if (current == 0 || current == 2)
        {
            Camera.main.GetComponent<CameraTransform>().isLeft = true;
        }
        else
        {
            Camera.main.GetComponent<CameraTransform>().isLeft = false;
        }
       
    }
    void StartIns()
    {
        EnemyIns(0);
    }

    public void TakeDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
        else
        {
            Die();
        }
    }
    void Die()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        control.OutOfCar(true);
        control.Die();
        isDoing = false;
        
    }
    


}
