using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBattleManager : MonoBehaviour
{
    public GameObject[] things;
    public Transform manager;
    public bool isActive = false; 
    public float timerStart;
    private GameObject inst;
    
    // Start is called before the first frame update
    void Start()
    {
        timerStart += Random.Range(10, 20);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == true)
        {
            if (timerStart <= 0)
            {
                int rand = Random.Range(0, things.Length);
                float randPos = Random.Range(-10, 10);
                inst = Instantiate(things[rand], new Vector3(transform.position.x + randPos, transform.position.y + 10, 0), Quaternion.identity, manager.transform) as GameObject;
                inst.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                inst.AddComponent<Rigidbody2D>();
                inst.GetComponent<BoxCollider2D>().isTrigger = false;
                timerStart += Random.Range(10, 20);
            }
            else
            {
                timerStart -= Time.deltaTime;
            }
            
        }

    }
}
