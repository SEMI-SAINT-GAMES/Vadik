using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject endGameUI;
    public Animator animo;

    void Start()
    {
        animo = GetComponent<Animator>();

    }

    
    
private void OnCollisionEnter2D(Collision2D collision)
{
        Control control = collision.gameObject.GetComponent<Control>();
        if (control != null)
        {
            Invoke("FlagUp", 3f);
            animo.SetBool("End", true);
            control.DefPosition();
        }
    }

    public void EndGame()
    {
        LevelController1.instance.isEndGame();
    }

    void FlagUp()
    {
        endGameUI.SetActive(true);
    }


}
