using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDropper : MonoBehaviour
{
    private int numCoin;
    private float xRange;
    private float yRange;

    public GameObject coin;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        numCoin = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dropCoin()
    {
        for(int i = 0; i < numCoin; i++)
        {
            xRange = Random.Range(-0.5f, 0.5f);
            yRange = Random.Range(-0.2f, 0.2f);
            position = new Vector3(transform.position.x + xRange, transform.position.y + yRange, transform.position.z);
            Instantiate(coin, position, Quaternion.identity);
        }
    }
}
