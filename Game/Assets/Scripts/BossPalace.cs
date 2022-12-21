using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPalace : MonoBehaviour
{
    public int currentBoss;
    public GameObject doorButton;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("CurrentBoss", currentBoss);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        Control control = collision.GetComponent<Control>();
        if (control != null)
        {
            control.inPalace = true;
            doorButton.SetActive(true);
            
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        Control control = collision.GetComponent<Control>();
        if (control != null)
        {
            control.inPalace = false;
            doorButton.SetActive(false);
        }
    }
}
