using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovGround : MonoBehaviour
{
    bool movRight;
    public float PosOfPatr;
    public float speed;
    public Transform point;
    public Transform player;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (transform.position.x < player.position.x - 30f)
        {
            gameObject.SetActive(false);
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < 50)
        {
            Do();
        }
    }
    public void Do()
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
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);

            }
            else
            {
                transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(point.position.x + PosOfPatr, point.position.y), new Vector2 (point.position.x - PosOfPatr, point.position.y));
    }


}
