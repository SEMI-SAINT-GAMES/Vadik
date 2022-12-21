using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EduManagerBoss : MonoBehaviour
{
    public EducationManager educationManager;
    public Dialog dialog;
    // Start is called before the first frame update
    void Start()
    {
        educationManager = GameObject.FindGameObjectWithTag("EduManager").GetComponent<EducationManager>();
        Invoke("Dial", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Dial()
    {
        educationManager.StartDialog(dialog);
    }
}
