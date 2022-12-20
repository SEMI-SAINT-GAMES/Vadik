using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterAmmo : EnemtAmmo
{
    public Transform hero;
    public float f;
    public float transformX;
    // Start is called before the first frame update
    void Start()
    {
        Asign();
        hero = GameObject.FindWithTag("Player").transform;
        transformX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Do();
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Control herohealth = collision.gameObject.GetComponent<Control>();
        if (herohealth != null)

        {
            herohealth.TakeUron(uron);
        }
        Destroy(gameObject);
        
    }
}
