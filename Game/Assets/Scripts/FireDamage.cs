using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Control control = collision.GetComponent<Control>();
        if(control != null)
        {
            if (timer <= 0)
            {
                control.TakeUron(1);
                timer = 0.5f;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }
}
