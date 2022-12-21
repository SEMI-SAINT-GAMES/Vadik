using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyrovWalking : StateMachineBehaviour
{
    public float attackRange;
    public Transform player;
    Rigidbody2D rb;
    public float speed;
    public bool heroAlive = true;
    Boss boss;
    BossHealth bossHealth;
    public string[] triggers = new string[3];
    public int rand;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        /*triggers[0] = "LegAtack";
        triggers[2] = "ArmAtack";
        triggers[3] = "DoubleLegAtack";*/
        
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
        bossHealth = animator.GetComponent<BossHealth>();
        rand = Random.Range(0, 2);
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPose =  Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
        

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            if (bossHealth.active == false)
            {
                
                animator.SetTrigger(triggers[rand]);
            }
        }
        else
        {
            rb.MovePosition(newPose);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
            animator.ResetTrigger(triggers[rand]);
        

    }

   
}
