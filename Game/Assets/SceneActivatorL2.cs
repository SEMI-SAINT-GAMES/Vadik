using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneActivatorL2 : MonoBehaviour
{
    public int CurrentScene;
    public Animator CharAnim;
    public string trigger;
    public bool isActivated;
    public bool isEnd;
    // Start is called before the first frame update
    void Start()
    {
        
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
            CharAnim.SetTrigger(trigger);
            isActivated = true;
            control.speed = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Control control = collision.gameObject.GetComponent<Control>();
        if (control != null)
        {
            CharAnim.SetTrigger(trigger);
            isActivated = true;
            control.speed = 0;
        }
        
    }
    public void ButClick()
    {
        if (isActivated)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            CharAnim.SetTrigger("EndFixedSpeaking");
            isActivated = false;
            
        }
        
    }
}
