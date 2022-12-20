using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemtAmmo : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    public int uron ;
    public bool movRight;
    public GameObject blood;


    // Start is called before the first frame update
    void Start()
    {
        Asign();
    }
    public void Asign()
    {
        Invoke("DestroyAmmo", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        Do();

    }
    public void Do()
    {
        if (movRight == false)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    public void DestroyAmmo()
    {
        Destroy(gameObject);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {

        Control herohealth = collision.gameObject.GetComponent<Control>();
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
    public void OnTriggerEnter2D(Collider2D collision)
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
    }
}
