using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigOrkPatrool : EnemyPatrool
{
    public float rayDistance;
    public float jumpForce;
    public Transform rayPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        Asign();
        Physics2D.queriesStartInColliders = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            Do();
            if (angr && Vector2.Distance(player.position, transform.position) > 2 && alive)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            }

            if (movRight == true)
            {

                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector2.right, rayDistance, LayerMask.GetMask("TileMap"));
                if (hit.collider != null)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    anim.SetTrigger("Jump");
                }
            }
            else if (movRight == false)
            {

                RaycastHit2D hit = Physics2D.Raycast(rayPoint.position, transform.localScale.x * Vector2.left, rayDistance, LayerMask.GetMask("TileMap"));
                if (hit.collider != null)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    anim.SetTrigger("Jump");
                }
            }
            if (angr)
            {
                Shoot();
            }
        }
    }
}
