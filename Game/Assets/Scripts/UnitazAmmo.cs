using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitazAmmo : EnemtAmmo
{
    public float rayDistance;
    public Quaternion q;
    public Quaternion UniRot;
    public float qRotate;
    public GameObject hero;
    public GameObject explosion;
    public Control control;
    // Start is called before the first frame update
    void Start()
    {
        Asign();
        q = Quaternion.Euler(0, 0, 0);
        UniRot = Quaternion.Euler(0, 0, 0);
        hero = GameObject.FindWithTag("Player");
        control = hero.GetComponent<Control>();
    }

    // Update is called once per frame
    void Update()
    {
        Do();
        transform.Rotate(0, 0, qRotate *Time.deltaTime);
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(explosion, transform.position, UniRot);
        Invoke("ExplosionMinus", 1f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector2.right, rayDistance, LayerMask.GetMask("Hero"));
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, transform.localScale.x * Vector2.left, rayDistance, LayerMask.GetMask("Hero"));
        if (hit.collider != null || hitLeft.collider != null)

        {
            control.TakeUron(uron);
        }
        Destroy(gameObject);
    }
    private void ExplosionMinus()
    {
        Destroy(explosion);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.left * rayDistance);
    }
}
