using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFunction : MonoBehaviour
{
    public float health = 100f;
    public GameObject deathEffect;
    public Rigidbody2D self;
    public float thrust = 5f;
    public float knockTime = 0.3f;

    public GameObject scoreManager;

    private CoinDropper cd;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>().gameObject;
        cd = GetComponent<CoinDropper>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            ScoreManager.score++;
            Die();
        }
    }

    public void TakeDamage(float damage, Transform player)
    {
        health -= damage;
        StartCoroutine(KnockBack(player));
    }

    public void Die()
    {
        SpawnerManager.enemyAlive--;
        //GameManagerScript.Instance.GetComponent<SpawnerManager>().enemyAlive--;
        Destroy(gameObject);
        GameObject efx = Instantiate(deathEffect, transform.position, Quaternion.identity);
        efx.GetComponent<SpriteRenderer>().sortingOrder = gameObject.GetComponent<SpriteRenderer>().sortingOrder;
        cd.dropCoin();
        Destroy(efx, 0.5f);
    }
    private IEnumerator KnockBack(Transform enemy)
    {
        if (self)
        {
            GetComponent<EnemyController>().canMove = false;
            Vector2 difference = transform.position - enemy.position;
            difference = difference.normalized * thrust;
            self.AddForce(difference, ForceMode2D.Impulse);
            yield return new WaitForSeconds(knockTime);
            self.velocity = Vector2.zero;
            GetComponent<EnemyController>().canMove = true;
        }
    }

    public void TakeDamageArrow(float damage)
    {
        health -= damage;
    }
}
