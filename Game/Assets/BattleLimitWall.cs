using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLimitWall : MonoBehaviour
{
    public GameObject killAllOrksText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Control control = collision.gameObject.GetComponent<Control>();
        if (control != null)
        {
            killAllOrksText.SetActive(true);
            Invoke("ObjDestr", 1.5f);
        }
    }
    private void ObjDestr()
    {
        killAllOrksText.SetActive(false);
    }
}
