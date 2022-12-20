using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KopterObjects : MonoBehaviour
{
    public int i;
    public Animator anim;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
     
    }
   

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        KopterController kopterController = collision.gameObject.GetComponent<KopterController>();
        if (kopterController != null)
        {
            kopterController.objectCounter = i;
        }
    }
    public void AnimoActive()
    {
        
        anim.SetBool("Exp", true);
    }
}
