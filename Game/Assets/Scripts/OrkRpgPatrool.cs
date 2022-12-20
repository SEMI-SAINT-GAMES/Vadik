using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrkRpgPatrool : EnemyPatrool
{
    public float rayDistance;
    public float jumpForce;
    public Transform rayPoint;
    public float ready;
    public Sprite readySprite;
    public Sprite emptySprite;
    public bool isReady;
    
    // Start is called before the first frame update
    void Start()
    {
        Asign();
        anim.SetBool("Run", true);

    }

    // Update is called once per frame
    void Update()
    {
        Do();
       
        if (alive)
        {

            if (angr)
            {
                if (timeShot > ready)
                {
                    isReady = false;
                    if (isShooting == false)
                    {
                        anim.SetBool("ready", false);
                       
                       
                        
                    }
                }
                else if (timeShot <= ready)
                {
                    anim.SetBool("ready", true);
                    isReady = true;
                }
                if (Vector2.Distance(player.position, transform.position) >= 2 && !isReady)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                    anim.SetBool("Run", true);
                }
                else if (Vector2.Distance(player.position, transform.position) < 2)
                {
                    anim.SetBool("Run", false);
                }
            }


            if (isShooting == true)
            {

                anim.SetBool("ready", false);
            }
            timeShot -= Time.deltaTime;




            if (movRight == true)
            {

                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector2.left, rayDistance, LayerMask.GetMask("TileMap"));
                if (hit.collider != null)
                {
                    rb.velocity = Vector2.up * jumpForce;
                }
            }
            else if (movRight == false)
            {

                RaycastHit2D hit = Physics2D.Raycast(rayPoint.position, transform.localScale.x * Vector2.right, rayDistance, LayerMask.GetMask("TileMap"));
                if (hit.collider != null)
                {
                    rb.velocity = Vector2.up * jumpForce;
                }
            }
        }
    }
    public void ShootRPG()
    {
        if (movRight == true)
        {

            GameObject amm = Instantiate(ammo, shotDir.position, shotDir.rotation) as GameObject;
            amm.GetComponent<EnemtAmmo>().movRight = true;
            GameObject fir = Instantiate(fire, fireDir.position, shotDir.rotation) as GameObject;
            //fir.transform.localScale *= -1;
            fir.transform.rotation = Quaternion.Euler(0, 0, -90);

        }
        else if (movRight == false)
        {
            //enemtAmmo.movRight = false;
            GameObject amm = Instantiate(ammo, shotDir.position, shotDir.rotation) as GameObject;
            amm.GetComponent<EnemtAmmo>().movRight = false;
            GameObject fir = Instantiate(fire, fireDir.position, shotDir.rotation) as GameObject;
            fir.transform.rotation = Quaternion.Euler(0, 0, 90);

        }
        timeShot = startTime;
        isShooting = true;
        enShoot.Play();
        Invoke("Recharge", 1f);
    }
    public void SpriteChange(Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
    

}
