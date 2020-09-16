using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFunction : MonoBehaviour
{
    public float health = 100f;
    private float flashTime = 0.1f;
    private float knockTime = 0.4f;
    public Color newColor;
    public Color originalColor;
    public SpriteRenderer rend;
    public GameObject SpawnManager;

    public HealthBar hb;

    public Rigidbody2D player;
    public float thrust = 5f;

    public GameObject DeathUI;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        hb.SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            
            Die();
        }
        if (Input.GetButtonDown("Potion"))
        {
            if(health < 100f)
            {
                if(HealthPot.numPot > 0 && health < 80f)
                {
                    HealthPot.numPot--;
                    health += HealthPot.heal;
                    hb.SetHealth(health);
                }
                else if(HealthPot.numPot > 0 && health >= 80f)
                {
                    HealthPot.numPot--;
                    health = 100f;
                    hb.SetHealth(health);
                }
            }

        }
    }

    public void Die()
    {
        if(ScoreManager.score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", ScoreManager.score);
        }
        DeathUI.SetActive(true);
        SpawnManager.SetActive(false);
        Destroy(gameObject);
    }

    public void TakeDamage(float damage, Transform enemy)
    {
        health -= damage;
        StartCoroutine(DamageFlash());
        StartCoroutine(KnockBack(enemy));
        hb.SetHealth(health);
    }

    private IEnumerator DamageFlash()
    {
        rend.color = newColor;
        yield return new WaitForSeconds(flashTime);
        rend.color = originalColor;
        yield return new WaitForSeconds(flashTime);
        rend.color = newColor;
        yield return new WaitForSeconds(flashTime);
        rend.color = originalColor;
        yield return new WaitForSeconds(flashTime);
        rend.color = newColor;
        yield return new WaitForSeconds(flashTime);
        rend.color = originalColor;
    }

    private IEnumerator KnockBack(Transform enemy)
    {
        if (player)
        {
            GetComponent<PlayerController>().canMove = false;
            Vector2 difference = transform.position - enemy.position;
            difference = difference.normalized * thrust;
            player.AddForce(difference, ForceMode2D.Impulse);
            yield return new WaitForSeconds(knockTime);
            player.velocity = Vector2.zero;
            GetComponent<PlayerController>().canMove = true;
        }
    }



}
