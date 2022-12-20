using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirBossWalking : StateMachineBehaviour
{
    public float attackRange;
    public Transform player;
    public GameObject hero;
    Rigidbody2D rb;
    public float speed;
    public bool heroAlive = true;
    BossKir bossKir;
    BossHealth bossHealth;
    public string[] triggers = new string[2];
    public int rand;
    Control control;
    public float timer;
   

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        hero = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        /*triggers[0] = "LegAtack";
        triggers[2] = "ArmAtack";
        triggers[3] = "DoubleLegAtack";*/

        rb = animator.GetComponent<Rigidbody2D>();
        bossKir = animator.GetComponent<BossKir>();
        bossHealth = animator.GetComponent<BossHealth>();
        rand = Random.Range(0, 2);
        control = hero.GetComponent<Control>();
        bossHealth.isAttack = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossKir.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPose = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);


        if (Vector2.Distance(player.position, rb.position) <= attackRange && control.isDead == false )
        {
            if (bossHealth.active == false)
            {

                animator.SetTrigger(triggers[rand]);
                
            }
            
        }
        else if (control.isDead)
        {
            animator.SetTrigger("Win");
        }
        else
        {
            rb.MovePosition(newPose);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossHealth.isAttack = true;
        animator.ResetTrigger(triggers[rand]);


    }


}
