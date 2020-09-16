using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointScript : MonoBehaviour
{
    public float health = 100f;

    [SerializeField]
    private float damage = 5f;

    private GameBar gameBar;

    public GameObject Player;
    public GameObject DeathUI;

    // Start is called before the first frame update
    void Start()
    {
        gameBar = FindObjectOfType<GameBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player)
        {
            if (health <= 0f)
               {
                    Player.GetComponent<PlayerFunction>().Die();
                    DeathUI.SetActive(true);
               }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "EnemyBody")
        {
            other.GetComponent<EnemyFunction>().Die();
            health -= damage;
            gameBar.SetHealth(health);
        }
    }
}
