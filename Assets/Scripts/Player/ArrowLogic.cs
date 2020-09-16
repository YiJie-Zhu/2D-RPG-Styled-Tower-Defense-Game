using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLogic : MonoBehaviour
{
    private Rigidbody2D rb;
    public float shootingForce = 20f;
    public float damage = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        addForce();
    }

    void addForce()
    {
        rb.AddForce(transform.up * shootingForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hit = collision.gameObject;
        if (hit.GetComponent<EnemyFunction>())
        {
            hit.GetComponent<EnemyFunction>().TakeDamageArrow(damage);
        }
        Destroy(gameObject);
    }
}
