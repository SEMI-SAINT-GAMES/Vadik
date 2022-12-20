using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularOrkAmmo : EnemtAmmo
{
    // Start is called before the first frame update
    void Start()
    {
        Asign();
    }

    // Update is called once per frame
    void Update()
    {
        Do();
    }
    /*public void OnTriggerEnter2D(Collider2D collision)
    {
        Control herohealth = collision.GetComponent<Control>();
        if (herohealth != null)

        {
            herohealth.TakeUron(uron);
            Debug.Log(uron);
            if (movRight)
            {
                Instantiate(blood, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(blood, transform.position, Quaternion.Euler(0, 0, 180));
            }

        }
        Destroy(gameObject);
    }*/
}
