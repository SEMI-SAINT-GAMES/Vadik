using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Playsound : MonoBehaviour 


{
	public string enter;
    public string code;
    public GameObject betonBlock;
	public Text text;
    public AudioSource doorOpemSound;
    public AudioSource cancelSound;
    public AudioSource doneSound;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        text.text = enter;
    }
    public void Clicky (string number)
	{
        enter += number + " ";
		GetComponent<AudioSource>().Play();
	}
    public void EnterCode()
    {
       if (enter == code)
        {
            anim.SetTrigger("Done");
            doneSound.Play();
            betonBlock.GetComponent<CodeDoorActivator>().doorButton.SetActive(false);
            betonBlock.SetActive(false);
            Invoke("Close", 1.5f);
        }
       else
        {
            anim.SetTrigger("Cancel");
            DeleteText();
            cancelSound.Play();
        }
    }
    public void DeleteText()
    {
        enter = "";
    }
    public void DoorOpen()
    {
        doorOpemSound.Play();
    }
    void Close()
    {
        gameObject.SetActive(false);
    }
    


}
