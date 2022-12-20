using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowitzerAmmo : MonoBehaviour
{
    public GameObject explosion;
    
    public GameObject circle;
    public GameObject fire;
    private int i = 0;
    void Start()
    {
        
    }
    void Update()
    {
        if (i > 0 )
        {
            Fire();
        }
    }
     public void Exp()
    {
        Instantiate(explosion, transform.position + new Vector3(0, 0, -15), transform.rotation);
        
    }
    
    private void Fire()
    {
        float rand = Random.Range(-1f, 1f);
        Vector3 vector = new Vector3(transform.position.x + rand, transform.position.y + rand, transform.position.z);
        Instantiate(fire, vector, transform.rotation);
        i -= 1;
        
    }
    public void Iplus()
    {
        i = 4;
    }
    public void CircleIns()
    {
        Instantiate(circle, transform.position + new Vector3(0,0,15), transform.rotation);
    }
    void DestroyAmmo()
    {
        Destroy(gameObject);
    }
   
}
