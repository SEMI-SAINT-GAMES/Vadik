using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Howitzer : MonoBehaviour
{
    
    public int curentHow;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Control control = collision.gameObject.GetComponent<Control>();
        if (control != null)
        {
            PlayerPrefs.SetInt("CurrentHowitzer", curentHow);
            control.Invoke("HowitzerPanel", 1f);
            control.speed = 0;
            PlayerPrefs.SetFloat("PlayerPosX", transform.position.x + 1.5f);
            PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
