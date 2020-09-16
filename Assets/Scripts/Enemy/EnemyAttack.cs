using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 10f;
    public float attackDelay = 0f;
    public float attackTime = 0f;
    private bool canAttack = false;
    public Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > attackTime)
        {
            canAttack = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlayerBody" && canAttack)
        {
            StartCoroutine(AttackStart(other));
            StartCoroutine(AttackStop());
            
            attackTime = Time.time + attackDelay;
            canAttack = false;
        }
    }

    private IEnumerator AttackStop()
    {
        float originalSpeed = gameObject.transform.parent.GetComponent<EnemyController>().speed;
        gameObject.transform.parent.GetComponent<EnemyController>().speed = 0f;
        yield return new WaitForSeconds(0.3f);
        gameObject.transform.parent.GetComponent<EnemyController>().speed = originalSpeed;
    }

    private IEnumerator AttackStart(Collider2D other)
    {
        ani.SetTrigger("IsAttack");
        yield return new WaitForSeconds(0.2f);
        other.GetComponent<PlayerFunction>().TakeDamage(damage, transform);
    }
}
