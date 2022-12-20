using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StugnaPatrool : MonoBehaviour
{
    public float speed;
    public bool movRight;
    public Animator anim;
    public GameObject exp;
    
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Stugna0();
    }
    public void Stugna0()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
    
        

   public void ExplIns()
    {
        GameObject newObj = Instantiate(exp, transform.position, transform.rotation) as GameObject;
        newObj.transform.position += new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0);
        newObj.transform.localScale = new Vector3(Random.Range(2, 5), Random.Range(2, 5), 0);

    }
    public void Die()
    {
       
        anim.SetBool("Die", true);
        TankStop();
        StugnaAimControl st = GameObject.FindGameObjectWithTag("Player").GetComponent<StugnaAimControl>();
        st.destrCount += 1;
    }
    public void TankStop()
    {
        speed = 0;
    }

    
}
/* if (transform.position.x > point.position.x + PosOfPatr)
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
        }*/