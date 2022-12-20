using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StugnaPatrool1 : StugnaPatrool
{
    public float PosOfPatr;
    public Transform point;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > point.position.x + PosOfPatr)
        {
            movRight = false;
        }
        else if (transform.position.x < point.position.x - PosOfPatr)
        {
            movRight = true;
        }
        if (movRight)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
