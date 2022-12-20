using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour
{
    public EnemyPatrool enemyPatrool;
    // Start is called before the first frame update
    void Start()
    {
        enemyPatrool = GetComponentInParent<EnemyPatrool>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HeadShot()
    {
        enemyPatrool.Die();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AK47Ammo aK47Ammo = collision.gameObject.GetComponent<AK47Ammo>();
        if (aK47Ammo != null)
        {
            HeadShot();
            Debug.Log("head");
        }
    }
}
