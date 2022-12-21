using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AK47 : MonoBehaviour
{
    
    public Transform[] shotDirAk;
    public Transform[] fireDirAk;
    public GameObject ammo;

    public Animator anim;
    public GameObject ammoJav;
    public Transform shotDirJav;
    
    
    public Transform[] shotDirGrenade;
    public GameObject[] grenadeAmmos;
    public float timeShot;
    public float[] startTimeAk;
    public float[] startTimeJav;
    public float[] startTimeTank;
    public int[] ammoInWeapons;
    public int currentAmmo;
    public int allAmmo;
    bool akIsCharged = true;
    public int currentAmmoJav;
    public int allAmmoJav;
    public int fullAmmo = 0;
    
    [SerializeField]
    private Text ammoCount;
    
    public GameObject fire;
    public GameObject javelin;
    public GameObject[] hands;
    public GameObject[] grenadeHands;

    public Image javelButton;
    public GameObject Ak47;
    public AudioSource RechargeSound;
    public AudioSource magazinCollect;
    public AudioSource[] shootSound;
    public AudioSource javSound;
    bool javIsRecharging;
    public AudioSource rpgSound;
    public AudioSource[] grenadeSound;
    public GameObject ammoTank;
    
    public GameObject fireTank;
    public Transform[] shotDirTank;
    public Transform[] fireDirTank;
    public Transform[] shotDirTankBullet;
    public float[] tankShotTimers;
    public float tankShotTimer; 
    
    
    private SpriteRenderer ak;

    Control control;
    public GameObject smoke;
    public Transform[] smokeDir;
    
    public Sprite[] grenadeLaunchers;
    public Sprite[] akSprite;
    public Sprite[] emptyGrenade;
    public int currentGrenade;
    public int currentGrenade1;
    public bool javIsActiv;
    public bool collectingJav;
    public Image GrenadeOnSheet;  
    
    public GameObject grenadePanel;
    public int currentTank;
    public GameObject[] ammos;
    public int currentWeapon;
    public bool isShooting;
    public AudioSource tankRecharge;





    // Start is called before the first frame update
    void Start()
    {

        //PlayerPrefs.SetInt("GrenadeLaunch", 3);
        //PlayerPrefs.SetInt("GrenadeLaunch1", 3);
        //currentAmmoJav = PlayerPrefs.GetInt("CurrentAmmoJav");
        
        akSprite = GetComponent<Control>().weaponSprite;
        collectingJav = false;
        GrenadeActivate();
        javelButton.sprite = grenadeLaunchers[currentGrenade];
        javelButton.enabled = false;
        javIsActiv = false;
        control = GetComponent<Control>();
        currentWeapon = 0;
        if (allAmmoJav > 0)
        {
            javelButton.enabled = true;
            allAmmoJav -= 1;
            currentAmmoJav = 1;
        }
        else
        {
            javelButton.enabled = false;
        }
        //currentAmmo = ammoInWeapons[control.currentWeapon];
        Invoke("AkRecharge", 0.3f);
        //RechargeSound.Play();

    }

    // Update is called once per frame
    void Update()
    {
        currentGrenade = PlayerPrefs.GetInt("GrenadeLaunch");
        currentGrenade1 = PlayerPrefs.GetInt("GrenadeLaunch1");
        currentTank = PlayerPrefs.GetInt("CurrentTank");
        if (javIsActiv)
        {
            ammoCount.text = currentAmmoJav.ToString() + "/" + allAmmoJav.ToString();
        }
        else
        {
            ammoCount.text = currentAmmo.ToString() + " / " + allAmmo.ToString();
        }
        
       
        
        if (javIsActiv == true)
        {
            javelButton.sprite = akSprite[PlayerPrefs.GetInt("CurrentWeapon")];
        }
        else
        {
            javelButton.sprite = grenadeLaunchers[currentGrenade];
        }
        if (isShooting)
        {
            OnShootDown();
        }
        if (tankShotTimer >= 0)
        {
            tankShotTimer -= Time.deltaTime;
        }
        if (!akIsCharged)
        {
            shootSound[control.currentWeapon].Stop();
        }


        //PlayerPrefs.SetInt("CurrentAmmoJav", currentAmmoJav);

    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        javCollect jav = collision.gameObject.GetComponent<javCollect>();
        if (jav != null)
        {
            allAmmoJav += Random.Range(1, 10);
            PlayerPrefs.SetInt("CurrentAmmoJav", currentAmmoJav);
            magazinCollect.Play();
            javelButton.enabled = true;
            RpgRechargeEnd();
            Destroy(collision.gameObject);
            
        }
        AKmagazin aKmagazin = collision.gameObject.GetComponent<AKmagazin>();
        if (aKmagazin != null)
        {
            allAmmo += Random.Range(10, 40);
            Destroy(collision.gameObject);
            magazinCollect.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        javCollect jav = collision.GetComponent<javCollect>();
        if (jav != null)
        {
            allAmmoJav += Random.Range(1, 10);
            PlayerPrefs.SetInt("CurrentAmmoJav", currentAmmoJav);
            magazinCollect.Play();
            javelButton.enabled = true;
            RpgRechargeEnd();
            Destroy(collision.gameObject);
        }
        AKmagazin aKmagazin = collision.GetComponent<AKmagazin>();
        if (aKmagazin != null)
        {
            allAmmo += Random.Range(10, 40);
            Destroy(collision.gameObject);
            magazinCollect.Play();
        }
    }

    private void GrenadeActivate()
    {
        if (collectingJav == true)
        {
            Time.timeScale = 0;
            grenadePanel.SetActive(true);
            collectingJav = false;
            javelin.GetComponent<SpriteRenderer>().sprite = grenadeLaunchers[currentGrenade1];
            PlayerPrefs.SetInt("GrenadeLaunch", currentGrenade1);
        }
        else
        {
            javelin.GetComponent<SpriteRenderer>().sprite = grenadeLaunchers[currentGrenade];
        }

    }
    public void Continue()
    {
        grenadePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void JavActivate()
    {
        if (javIsActiv == false)
        {
            //Ak47.SetActive(false);
            //javelin.SetActive(true);
            foreach (GameObject hand in grenadeHands)
            {
                hand.SetActive(true);
            }
            foreach (GameObject hand in hands)
            {
                hand.SetActive(false);
            }
            PlayerPrefs.SetInt("SpriteCurrent", 3);
            currentWeapon = 2;
            javelin.GetComponent<SpriteRenderer>().sprite = grenadeLaunchers[currentGrenade];
            javIsActiv = true;
           
        }
        else
        {
            // Ak47.SetActive(true);
            //javelin.SetActive(false);
            foreach (GameObject hand in grenadeHands)
            {
                hand.SetActive(false);
            }
            foreach (GameObject hand in hands)
            {
                hand.SetActive(true);
            }
            PlayerPrefs.SetInt("SpriteCurrent", 0);
            currentWeapon = 0;

            javIsActiv = false;
            
        }

    }
    public void ShootDown()
    {
        isShooting = true;
        if (currentWeapon == 0)
        {
            if (control.currentWeapon != 1)
            {
                if (akIsCharged)
                {
                    shootSound[control.currentWeapon].Play();
                }
                else
                {
                    shootSound[control.currentWeapon].Stop();
                }
            }
        }
        else if (currentWeapon == 1)
        {
            shootSound[0].Play();
        }
    }
    public void ShootUp()
    {
        isShooting = false;
        timeShot = 0f;
        if (currentWeapon == 0)
        {
            if (control.currentWeapon != 1)
            {
                shootSound[control.currentWeapon].Stop();
            }
        }
        else if (currentWeapon == 1)
        {
            shootSound[0].Stop();
        }

    }

    public void OnShootDown()
    {
        if (timeShot <= 0)
        {
            if (currentWeapon == 0)
            {
                if (currentAmmo > 0)
                {
                    GameObject am = Instantiate(ammo, shotDirAk[control.currentWeapon].position, Quaternion.identity) as GameObject;
                    am.GetComponent<AK47Ammo>().isRight = control.isRight;
                    am.GetComponent<AK47Ammo>().currentAmmo = control.currentWeapon;
                    timeShot = startTimeAk[control.currentWeapon];
                    currentAmmo -= 1;
                    GameObject fir = Instantiate(fire, fireDirAk[currentWeapon].position, Quaternion.identity) as GameObject;
                    fir.GetComponent<Fire>().isRight = control.isRight;
                    if (control.currentWeapon == 1)
                    {
                        shootSound[1].Play();
                    }
                   
                }
                else if (currentAmmo <= 0 && akIsCharged)
                {
                    //ANIMATION!!!!
                    Invoke("AkRecharge", 2f);
                    RechargeSound.Play();
                    akIsCharged = false;
                    
                }

            }
            else if (currentWeapon == 1)
            {

                GameObject am = Instantiate(ammo, shotDirTankBullet[currentTank].position, transform.rotation) as GameObject;
                am.GetComponent<AK47Ammo>().isRight = control.isRight;
                am.GetComponent<AK47Ammo>().currentAmmo = control.currentTank;
                timeShot = startTimeTank[control.currentTank];
                Instantiate(fire, shotDirTankBullet[currentTank].position, transform.rotation);
                



            }

            else if (currentWeapon == 2)
            {
                if (currentAmmoJav > 0 && javIsRecharging == false)
                {
                    
                   
                        
                        GameObject am = Instantiate(grenadeAmmos[currentGrenade], shotDirGrenade[currentGrenade].position, Quaternion.identity) as GameObject;
                    if (!control.isRight)
                    {
                        Vector3 theScale = am.transform.localScale;
                        theScale.x *= -1;
                        am.transform.localScale = theScale;
                    }
                    am.GetComponent<AK47Ammo>().isRight = control.isRight;
                       // am.GetComponent<AK47Ammo>().currentAmmo = currentGrenade;
                            timeShot = startTimeJav[currentGrenade];
                        currentAmmoJav -= 1;
                    grenadeSound[currentGrenade].Play();
                    if (currentGrenade == 0)
                    {
                        javelin.GetComponent<SpriteRenderer>().sprite = emptyGrenade[0];

                    }


                    javIsRecharging = true;
                    Invoke("RpgRechargeEnd", startTimeJav[currentGrenade] - 0.3f);
                    GameObject sm = Instantiate(smoke, smokeDir[currentGrenade].position, smokeDir[currentGrenade].rotation) as GameObject;
                    sm.GetComponent<Smoke>().isRight = control.isRight;
                    /*else
                    {

                        GameObject am = Instantiate(ammoJav, shotDirRpg.position, transform.rotation) as GameObject;
                        am.GetComponent<AK47Ammo>().isRight = control.isRight;
                        am.GetComponent<AK47Ammo>().currentAmmo = currentGrenade;
                        timeShot = startTimeJav[currentGrenade];
                            currentAmmoJav -= 1;
                            
                            rpgSound.Play();
                            GameObject sm = Instantiate(smoke, smokeDir.position, smokeDir.rotation) as GameObject;
                        sm.GetComponent<Smoke>().isRight = control.isRight;
                            if (currentGrenade == 0)
                            {
                                javelin.GetComponent<SpriteRenderer>().sprite = emptyGrenade[0];
                                
                            }
                            else if (currentGrenade == 3)
                            {
                                javelin.GetComponent<SpriteRenderer>().sprite = emptyGrenade[1];
                                
                            }
                        
                        
                    }*/


                }
                else if (currentAmmoJav <= 0)
                {
                    Debug.Log("Empty");

                }
            }
        }
        else
        {
            timeShot -= Time.deltaTime;
        }

    }
    public void AkRecharge()
    {
        if (allAmmo >= ammoInWeapons[control.currentWeapon])
        {
            currentAmmo = ammoInWeapons[control.currentWeapon];
            allAmmo -= ammoInWeapons[control.currentWeapon];
        }
        else 
        {
            currentAmmo = allAmmo;
            allAmmo = 0;
        }
        akIsCharged = true;
    }
    public void RpgRechargeEnd()
    {
        Debug.Log("Recharge");
        if (allAmmoJav > 0)
        {
            if (currentGrenade == 0 || currentGrenade == 3)
            {
                javelin.GetComponent<SpriteRenderer>().sprite = grenadeLaunchers[currentGrenade];
            }
            currentAmmoJav = 1;
            allAmmoJav -= 1;
            javIsRecharging = false;
        }
        else
        {
            JavActivate();
            javelButton.enabled = false;
        }

    }
   
   
    public void TankShoot()
    {
        if (tankShotTimer <= 0)
        {

            GameObject am = Instantiate(ammoTank, shotDirTank[currentTank].position, transform.rotation) as GameObject;
            am.GetComponent<AK47Ammo>().isRight = control.isRight;
            timeShot = startTimeTank[control.currentTank];
            GameObject fr = Instantiate(fireTank, fireDirTank[currentTank].position, transform.rotation) as GameObject;
            fr.GetComponent<Fire>().isRight = control.isRight;
            fr.transform.localScale = new Vector3(0.1f, 0.35f, 0.01f);
            Invoke("TankRecharge", 0.4f);
            tankShotTimer = tankShotTimers[currentTank];
        }
        else
        {
            //Sound;
            Debug.Log("EmptyTank");
        }
        
        
    }
    void TankRecharge()
    {
        tankRecharge.Play();
    }
   

}

/* SpriteCurrent 
 * 0 = ak
 * 1 = Tank
 * 2 = Javelin
 * 3= 
 */
