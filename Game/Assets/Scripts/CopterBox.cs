using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CopterBox : MonoBehaviour
{
    private Animator anim;
    public int currentCopter;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if(player != null)
        {
            if(transform.position.x < player.position.x )
            {
                anim.SetBool("Opened", true);
                GetComponent<BoxCollider2D>().isTrigger = false;
            }
        }
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
            anim.SetBool("Open", true);
            PlayerPrefs.SetInt("CurrentCopter", currentCopter);
            PlayerPrefs.SetFloat("PlayerPosXBuf", control.transform.position.x + 3);
            PlayerPrefs.SetFloat("PlayerPosYBuf", control.transform.position.y);
            //control.SavePosition();

        }
    }
    public void CopterActiv()
    {
        GameObject.FindGameObjectWithTag("LoadingScreen").GetComponent<LoadingScreen>().Load("Kopter");
    }

}
