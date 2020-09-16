using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestPopUp : MonoBehaviour
{
    public GameObject popUpPF;
    private GameObject temp;
    public GameObject Shop;

    private bool In;
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "PlayerBody")
        {
            In = true;
            temp = Instantiate(popUpPF);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if(other.tag == "PlayerBody")
        {
            In = false;
            temp.GetComponentInChildren<Animator>().SetTrigger("exit");
            Destroy(temp, 0.2f);
        }
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Shop"))
        {
            if (In)
            {
                Shop.SetActive(true);
            }
        }
        
    }

}
