using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class BossHealth : MonoBehaviour
{
    public float health = 10;
    public GameObject healthBarObj;
    public Image healthBar;
    public Animator anim;
    public bool active = false;
    private Rigidbody2D rb;

    bool enraged;
    public BossBattleManager bossBattleManager;
    public bool isAttack;
    public PlayableDirector endDirector;
    // Start is called before the first frame update
    void Start()
    {
        // healthBar = GameObject.FindGameObjectWithTag("BossHealth").GetComponent<Image>();
        //healthBarObj = GameObject.FindGameObjectWithTag("BossHealthObj");
        
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        enraged = false;
        
        bossBattleManager = GameObject.Find("BossManager").GetComponent<BossBattleManager>();
        bossBattleManager.isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health * 0.002f;
        
    }
    public void TakeDamage(int damage)
    {
        
        if (!isAttack)
        {
            health -= damage;
            rb.AddForce(new Vector2(700, 0));

            if (health <= 300 && !enraged)
            {

                anim.SetBool("Enraged", true);
            }
            else
            {
                anim.SetTrigger("damage");
            }

            if (health <= 0)
            {
                active = true;
                Die();

            }
        }
    }
    
    void Die()
    {
        anim.SetBool("Die", true);
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<BoxCollider2D>().enabled = false;

        Invoke("Death", 3f);
        PlayerPrefs.SetFloat("PlayerPosX3", 0);
        PlayerPrefs.SetFloat("PlayerPosY3", 0);
    }
    void Death()
    {
        healthBarObj.SetActive(false);

        endDirector.Play();
        bossBattleManager.isActive = false;

    }
    
}
