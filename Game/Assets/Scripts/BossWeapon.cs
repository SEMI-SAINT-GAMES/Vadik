using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
	public int attackDamage = 20;
	public int enragedAttackDamage = 40;

	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;
	public GameObject knife;
	DyrovKnife dyrovKnife;
	Boss boss;
	public int jumpDamage;
	public Transform knifeDir;
	public Transform jumpDir;
	public Animator camAnim;
	public float rayDistance;
	public GameObject explosion;
	public void Start()
	{
		dyrovKnife = knife.GetComponent<DyrovKnife>();
		boss = GetComponent<Boss>();
		camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
	}

	public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<Control>().TakeUron(attackDamage);
		}
	}

	public void EnragedAttack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<Control>().TakeUron(enragedAttackDamage);
		}
	}
	public void KnifeAttack()
	{
		
		if (boss.isFlipped)
        {
			dyrovKnife.movRight = false;
        }
		else
        {
			dyrovKnife.movRight = true;
		}
		Instantiate(knife, knifeDir.position, Quaternion.identity);
	}
	public void JumpAtack()
    {
		camAnim.SetTrigger("Shake");
		Instantiate(explosion, jumpDir.position, Quaternion.identity);
		RaycastHit2D hit = Physics2D.Raycast(transform.position, jumpDir.localScale.x * Vector2.right, rayDistance, LayerMask.GetMask("Hero"));
		RaycastHit2D hitLeft = Physics2D.Raycast(jumpDir.position, jumpDir.localScale.x * Vector2.left, rayDistance, LayerMask.GetMask("Hero"));
		if (hit.collider != null)

		{
			Control control = hit.transform.GetComponent<Control>();
			
			if (control != null)
			{
				control.TakeUron(jumpDamage);
				
			}
			
			
		}
		if (hitLeft.collider != null)
        {
			Control controlLeft = hitLeft.transform.GetComponent<Control>();
			if(controlLeft != null)
            {
				controlLeft.TakeUron(jumpDamage);
			}
		}
		
	}


	void OnDrawGizmos()
	{
	
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, transform.localScale.x * Vector2.right * rayDistance);
		Gizmos.DrawLine(transform.position, transform.localScale.x * Vector2.left * rayDistance);
	}
	
}
