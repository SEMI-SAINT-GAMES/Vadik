using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EndCutSceneActivatorBoss : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject doorOpenButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DoorOpen()
    {
        director.Play();
        doorOpenButton.SetActive(false);
        gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<DeathManager>().ButtonOff();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Control control = collision.GetComponent<Control>();
        if (control != null)
        {
            doorOpenButton.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Control control = collision.GetComponent<Control>();
        if (control != null)
        {
            doorOpenButton.SetActive(false);
        }
    }
    
}
