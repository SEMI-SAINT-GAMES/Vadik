using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InBossEnter : MonoBehaviour
{
    public Transform wallPoint1;
    public Transform wallPoint2;
    public Transform bossPoint;
    public GameObject wall;
    public GameObject boss;
    public BossBattleManager bossBattleManager;
    public GameObject healthBarObj;
    

    // Start is called before the first frame update
    void Start()
    {
        healthBarObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Control control = collision.GetComponent<Control>();
        if (control != null)
        {
            control.speed = 0;
            Instantiate(wall, wallPoint2.position, Quaternion.identity);
            Instantiate(wall, wallPoint1.position, Quaternion.identity);
            healthBarObj.SetActive(true);
            Instantiate(boss, bossPoint.position, Quaternion.identity);
            bossBattleManager.isActive = true;
            
            Destroy(gameObject);

        }
    }

}
