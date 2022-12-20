using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLaunchBox : MonoBehaviour
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
        PlayerPrefs.SetString("GrenadeLaunchStr", "/");
    }

    // Update is called once per frame
    void Update()
    {
        currentWeapon = PlayerPrefs.GetInt("GrenadeLaunch1");
        currentWeaponStr = PlayerPrefs.GetString("GrenadeLaunchStr");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AK47 ak47 = collision.gameObject.GetComponent<AK47>();
        Control control = collision.gameObject.GetComponent<Control>();
        if (ak47 != null)
        {
            if (currentWeaponStr.Contains(weaponStr)) 
            {
                weaponBoxAnim.SetBool("Open", true);
                GetComponent<BoxCollider2D>().enabled = false;
                Debug.Log("gg");
                
            }
            else
            {
                weaponBoxAnim.SetBool("Open", true);
                PlayerPrefs.SetInt("GrenadeLaunch1", weapon);
                PlayerPrefs.SetString("GrenadeLaunchStr", currentWeaponStr + "/"+ weaponStr);
                ak47.Invoke("GrenadeActivate", 1.3f);
                control.speed = 0f;
                ak47.collectingJav = true;
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        

    }
}
