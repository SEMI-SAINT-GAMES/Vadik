using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shovel : MonoBehaviour
{
    public Image shovelButton;
    private Animator anim;
    public GameObject ground;
    public Transform groundDir;
    public GameObject particleGround;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //shovelButton.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DoShovel()
    {
        anim.SetTrigger("Shovel");
    }
    public void DestrGround()
    {
        if (ground != null)
        {
            Destroy(ground);
        }
    }
    public void PartGrIns()
    {
        Vector3 pos = new Vector3(groundDir.position.x + Random.Range(-0.3f, 0.3f), groundDir.position.y + Random.Range(-0.2f, 0.2f), groundDir.position.z);
        Instantiate(particleGround, pos, Quaternion.Euler(-180, 90, 0));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SecretGround secretGround = collision.GetComponent<SecretGround>();
        if (secretGround != null)
        {
            shovelButton.gameObject.SetActive(true);
            ground = secretGround.parent;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        SecretGround secretGround = collision.GetComponent<SecretGround>();
        if (secretGround != null)
        {
            shovelButton.gameObject.SetActive(false);
            
        }
    }
}
