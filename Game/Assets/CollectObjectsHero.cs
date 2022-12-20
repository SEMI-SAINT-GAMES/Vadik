using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CollectObjectsHero : MonoBehaviour
{
    public Transform holdPoint;
    private GameObject collect;
    public bool isHold;
    public PlayableDirector director;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHold)
        {
            collect.transform.position = holdPoint.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Collect"))
        {
            collect = collision.gameObject;
            isHold = true;
        }
        if (isHold && collision.gameObject.tag.Equals("Collector"))
        {
            isHold = false;
            director.Play();
        }
    }
}
