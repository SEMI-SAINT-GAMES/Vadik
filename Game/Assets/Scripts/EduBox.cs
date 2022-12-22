using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EduBox : MonoBehaviour
{
    public int currentEdu;
    public EducationManager educationManager;
    public Dialog dialog;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Asign();
        
    }
    public void Asign()
    {
        educationManager = GameObject.FindGameObjectWithTag("EduManager").GetComponent<EducationManager>();
        
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
            /* if (currentEdu <= PlayerPrefs.GetInt("CurrentEdu") && currentEdu != 0)
             {
                 Destroy(gameObject);
             }
             else
             {
                 educationManager.Activate(currentEdu);
                 control.speed = 0;
                 PlayerPrefs.SetInt("CurrentEdu", currentEdu);
                 Destroy(gameObject);
             }*/

            GetDialog();
            Destroy(GetComponent<BoxCollider2D>());

        }
       

    }
    public void GetDialog()
    {

        educationManager.StartDialog(dialog);
        
    }

}


