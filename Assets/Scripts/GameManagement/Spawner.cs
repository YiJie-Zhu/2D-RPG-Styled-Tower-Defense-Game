using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private int difficulty;

    public GameObject enemy;



    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        difficulty = SpawnerManager.enemyAlive;//GameManagerScript.Instance.GetComponent<SpawnerManager>().enemyAlive;
        StartCoroutine(Spawn());
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginWave()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        for(int i = 0; i < difficulty; i++)
        {
            Instantiate(enemy, gameObject.transform.GetChild(UnityEngine.Random.Range(0,4)).position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}
