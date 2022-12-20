using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLimit : MonoBehaviour
{
    CameraTransform cameraTransform;
    public float leftLimit;
    public float rightLimit;
    public int enCount;
    public int allEn;
    public GameObject[] walls;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enCount >= allEn)
        {
            cameraTransform.inBattle = false;
            
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Control control = collision.GetComponent<Control>();
        if (control != null)
        {
            cameraTransform.leftLimit = transform.position.x - leftLimit;
            cameraTransform.rightLimit = transform.position.x + rightLimit;
            cameraTransform.inBattle = true;
            walls[0].SetActive(true);
            walls[1].SetActive(true);
        }
    }
   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector2(transform.position.x - leftLimit, transform.position.y), new Vector2(transform.position.x + rightLimit, transform.position.y));
        
    }
}
