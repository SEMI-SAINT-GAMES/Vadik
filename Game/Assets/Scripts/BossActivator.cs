using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossActivator : MonoBehaviour
{
    public Animator bossAnim;
    public GameObject healthBar;
    // Start is called before the first frame update
    void Start()
    {
        bossAnim.SetTrigger("ToWalk");
        healthBar.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
