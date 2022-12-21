using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovGroundVertical : MonoBehaviour
{
    bool movRight;
    public float PosOfPatr;
    public float speed;
    public Transform point;
    private Transform player;

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
            if (transform.position.y > point.position.y + PosOfPatr)
            {
                movRight = false;
            }
            else if (transform.position.y < point.position.y - PosOfPatr)
            {
                movRight = true;
            }
            if (movRight)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);

            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(point.position.x , point.position.y + PosOfPatr), new Vector2(point.position.x , point.position.y - PosOfPatr));
    }
}
