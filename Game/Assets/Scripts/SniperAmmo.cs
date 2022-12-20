using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAmmo : MonoBehaviour
{
    public float speed;
    public GameObject blood;
    public int damage;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyAmmo", 4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        SniperEnemy sniperEnemy = collision.gameObject.GetComponent<SniperEnemy>();
        if (sniperEnemy != null)
        {
            sniperEnemy.TakeDamage(damage);
            Instantiate(blood, transform.position, transform.rotation);
            DestroyAmmo();
        }
        SniperEnemyHead sniperEnemyHead = collision.gameObject.GetComponent<SniperEnemyHead>();
        if (sniperEnemyHead != null)
        {
            sniperEnemyHead.Die();

            DestroyAmmo();
            Debug.Log("kk");

        }
    }

    

    private void DestroyAmmo()
    {
        Destroy(gameObject);
    }
}
