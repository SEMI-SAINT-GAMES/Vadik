using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int price = 1;
    CoinManager coinManager;
    public GameObject particle;
    public float rotationSpeed;
    public AudioSource col;
    // Start is called before the first frame update
    void Start()
    {
        coinManager = GameObject.FindGameObjectWithTag("CoinManager").GetComponent<CoinManager>();
        col = GameObject.Find("CoinSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Control control = collision.GetComponent<Control>();
        if (control != null)
        {
            coinManager.CoinPlus(price);
            Instantiate(particle, transform.position, transform.rotation);
            Destroy(gameObject);
            col.Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Control control = collision.gameObject.GetComponent<Control>();
        if (control != null)
        {
            coinManager.CoinPlus(price);
            Instantiate(particle, transform.position, Quaternion.Euler(0,0,0));
            Destroy(gameObject);
            col.Play();
        }
    }
}
