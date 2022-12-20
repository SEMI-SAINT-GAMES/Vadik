using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperPatrool : SniperEnemy
{
    public Transform point;
    public float PosOfPatr;
    public bool movRight;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Asign();
    }

    // Update is called once per frame
    void Update()
    {
        Patrool();
    }
    public void Patrool()
    {
        if (health > 0)
        {
            if (transform.position.x > point.position.x + PosOfPatr)
            {
                if (movRight)
                {
                    Flip();
                }
                movRight = false;
            }
            else if (transform.position.x < point.position.x - PosOfPatr)
            {
                if (!movRight)
                {
                    Flip();
                }
                movRight = true;
            }
            if (movRight)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);

            }
            else
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);

            }
        }
    }
    void Flip()
    {
        movRight = !movRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
