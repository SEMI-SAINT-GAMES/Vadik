using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StugnaP : MonoBehaviour
{
    public int curentStugna;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (transform.position.x < player.position.x)
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Control control = collision.GetComponent<Control>();
        if (control != null)
        {
            PlayerPrefs.SetInt("CurrentStugna", curentStugna);
            control.speed = 0;
            PlayerPrefs.SetFloat("PlayerPosXBuf", control.transform.position.x + 10);
            PlayerPrefs.SetFloat("PlayerPosYBuf", control.transform.position.y);
            Invoke("StugnaEnter", 1.5f);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    void StugnaEnter()
    {
        LoadingScreen loading = GameObject.FindGameObjectWithTag("LoadingScreen").GetComponent<LoadingScreen>();
        loading.Load("Stugna");
    }
}
