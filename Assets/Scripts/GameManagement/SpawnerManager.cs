using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnerManager : MonoBehaviour
{

    public int level;
    static public int enemyAlive;
    [SerializeField]
    public GameObject spawner;

    private bool waiting;

    public GameObject waveText;
    public GameObject moleCounter;
    [SerializeField]
    public GameBar gameBar;
    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        enemyAlive = level;

        Debug.Log(level);
        waiting = true;

        spawner.SetActive(false);


        gameBar.SetMaxHealth(100f);

    }

    private void Awake()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
        if (enemyAlive > 0)
        {
            if (!spawner.activeSelf)
            {
                Debug.Log("updated");
                StartLevel();
            }
        }
        else if (waiting)
        {
            EndLevel();
            StartCoroutine(GracePeriod());
            waiting = false;
        }

    }

    void StartLevel()
    {
        spawner.SetActive(true);
    }

    void EndLevel()
    {
        spawner.SetActive(false);
    }

    private IEnumerator GracePeriod()
    {
        waveText.SetActive(true);
        waveText.GetComponent<TextMeshProUGUI>().fontSize = 90f;
        waveText.GetComponent<TextMeshProUGUI>().text = "Wave " + level.ToString() + " Has Ended";
        yield return new WaitForSeconds(4f);
        waveText.SetActive(false);
        yield return new WaitForSeconds(10f);
        level++;
        enemyAlive = level;
        waiting = true;
        waveText.SetActive(true);
        waveText.GetComponent<TextMeshProUGUI>().fontSize = 180f;
        waveText.GetComponent<TextMeshProUGUI>().text = "Wave " + level.ToString();
        yield return new WaitForSeconds(4f);
        waveText.SetActive(false);
    }
}
