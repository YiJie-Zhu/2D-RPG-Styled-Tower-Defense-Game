using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlayerBody")
        {
            CoinManager.coin += 10;
            Destroy(gameObject);
        }
    }
}
