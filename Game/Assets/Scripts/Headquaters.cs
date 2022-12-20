using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headquaters : MonoBehaviour
{
    private Animator anim;
    public Transform player;
    public GameObject SaveMiniature;
    bool isSave = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Invoke("CheckTrans", 0.3f);
    }
    void CheckTrans()
    {
        if (transform.position.x < player.position.x)
        {
            anim.SetBool("Done", true);
            GetComponent<BoxCollider2D>().isTrigger = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Control control = collision.GetComponent<Control>();
        if (control != null)
        {
            anim.SetBool("Save", true);
            if (!isSave)
            {
                Instantiate(SaveMiniature, transform.position, transform.rotation);
                isSave = true;
            }
        }
    }
}
