using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator ani;
    private GameObject player;
    private PlayerController pc;
    public GameObject parent;



    // Start is called before the first frame update
    void Start()
    {

        player = transform.parent.gameObject;
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && !PlayerBow.isBow)
        {
            ani.SetTrigger("IsPunch");
            pc.speed = 2f;
            if (pc.position == 1)
            {
                parent.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if(pc.position == 2)
            {
                parent.transform.GetChild(2).gameObject.SetActive(true);
            }
            else if(pc.position == 3)
            {
                parent.transform.GetChild(1).gameObject.SetActive(true);
            }
            else if(pc.position == 4)
            {
                parent.transform.GetChild(3).gameObject.SetActive(true);
            }
            Invoke("Revert", 0.3f);
        }

    }

    void Revert()
    {
        pc.speed = 5f;
        for(int i = 0; i < parent.transform.childCount; i++)
        {
            parent.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    
}
