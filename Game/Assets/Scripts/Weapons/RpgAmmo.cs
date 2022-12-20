using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RpgAmmo : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    public int damage;
    public GameObject explosion;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyAmmo", destroyTime);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);


    }
    void DestroyAmmo()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
        if (enemy != null)

        {
            enemy.TakeDamage(damage);
            Instantiate(explosion, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}

