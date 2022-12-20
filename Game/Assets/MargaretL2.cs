using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MargaretL2 : MonoBehaviour
{
    private GameObject tigr;
    public Transform building;
    public float speedToBuilding;
    public bool toBuilding;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        tigr = GameObject.FindGameObjectWithTag("Tigr");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toBuilding)
        {
            Run();
        }
        if (transform.position.x > building.position.x - 3 && toBuilding)
        {
            toBuilding = false;
            Win();

        }
    }
    public void InCarEnter()
    {
        gameObject.SetActive(false);
        tigr.GetComponent<BoxCollider2D>().enabled = true;
       
    }
    public void Run()
    {
        Vector2 target = new Vector2(building.position.x, transform.position.y);
        Vector2 newPose = Vector2.MoveTowards(transform.position, target, speedToBuilding * Time.deltaTime);
        transform.position = newPose;
    }
    public void ToWin()
    {
        toBuilding = true;
        anim.SetTrigger("Running");
    }
    public void Win()
    {
        anim.SetTrigger("Idle");
    }

}
