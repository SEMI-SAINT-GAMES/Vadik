using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDialogTigr : MonoBehaviour
{
    public Dialog dialog;
    EducationManager educationManager;
    // Start is called before the first frame update
    void Start()
    {
        educationManager = GameObject.FindGameObjectWithTag("EduManager").GetComponent<EducationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetDialog()
    {
        educationManager.StartDialog(dialog);
    }
}
