using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirBossWeapon : MonoBehaviour
{
    public int attackDamage;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    BossKir bossKir;
    public GameObject z;
    ZAmmo zAmmo;
    public Transform zDir;
    public Transform knifeDir;
    public GameObject knife;
    KirKnife kirKnife;

    // Start is called before the first frame update
    void Start()
    {
        zAmmo = z.GetComponent<ZAmmo>();
        kirKnife = knife.GetComponent<KirKnife>();
        bossKir = GetComponent<BossKir>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Attack()
    {
        

        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponentInParent<Control>().TakeUron(attackDamage);
            

        }
    }
    public void ZAttack()
    {
        if (bossKir.isFlipped)
        {
            zAmmo.movRight = true;
        }
        else
        {
            zAmmo.movRight = false;
        }
        Instantiate(z, zDir.position, Quaternion.identity);
    }
    public void KnifeAttack()
    {
        if (bossKir.isFlipped)
        {
            kirKnife.movRight = true;
        }
        else
        {
            kirKnife.movRight = false;
        }
        Instantiate(knife, knifeDir.position, Quaternion.identity);
    }
}
