using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeroTank : MonoBehaviour
{
    public int tank;
    public string tankStr;
    private int currentTank;
    private string currentTankStr;
    public Animator animo;
    void Start()
    {
        animo = GetComponent<Animator>();
    }

    void Update()
    {
        currentTank = PlayerPrefs.GetInt("CurrentTank1");
        currentTankStr = PlayerPrefs.GetString("CurrentTankStr");
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Control control = collision.gameObject.GetComponent<Control>();
        if (control != null)
        {
            if (currentTankStr.Contains(tankStr))
            {
                animo.SetBool("open", true);
                Invoke("Opened", 1.6f);
                GetComponent<BoxCollider2D>().enabled = false;
                Debug.Log("hh");


            }
            else
            {
                
                animo.SetBool("open", true);
                control.collectingTank = true;
                control.speed = 0;
                PlayerPrefs.SetInt("CurrentTank1", tank);
                PlayerPrefs.SetString("CurrentTankStr", currentTankStr + "/" + tank);
                GetComponent<BoxCollider2D>().enabled = false;
                control.Invoke("TankPanelActivate", 1.5f);
                animo.SetBool("open", true);
                Invoke("Opened", 1.6f);
            }
        }
    }
    public void Opened()
    {
        animo.SetBool("open", false);
    }

}
