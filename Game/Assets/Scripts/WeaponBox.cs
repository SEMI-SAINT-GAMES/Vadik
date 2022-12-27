using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBox : MonoBehaviour
{
    public int weapon;
    public string weaponStr;
    private int currentWeapon;
    private string currentWeaponStr;
    private Animator weaponBoxAnim;
   
    // Start is called before the first frame update
    void Start()
    {
        weaponBoxAnim = GetComponent<Animator>();
        
        //PlayerPrefs.SetString("CurrentWeaponStr", "0");
    }

    // Update is called once per frame
    void Update()
    {
        currentWeapon = PlayerPrefs.GetInt("CurrentWeapon1");
        currentWeaponStr = PlayerPrefs.GetString("CurrentWeaponStr");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Control control = collision.gameObject.GetComponent<Control>();
        if (control != null)
        {
            if (currentWeaponStr.Contains(weaponStr)) 
            {
                weaponBoxAnim.SetBool("Open", true);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<AudioSource>().Play();
                
            }
            else
            {
                control.collecting = true;
                weaponBoxAnim.SetBool("Open", true);
                GetComponent<AudioSource>().Play();
                control.speed = 0;
                control.currentWeapon1 = weapon;
                PlayerPrefs.SetInt("CurrentWeapon1", weapon);
                PlayerPrefs.SetString("CurrentWeaponStr", currentWeaponStr + "/" + weaponStr);
                
                control.Invoke("WeaponActivateSprite", 1.3f);
                
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        

    }
    
}
