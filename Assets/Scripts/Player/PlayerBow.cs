using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBow : MonoBehaviour
{
    public static bool isBow;
    private GameObject player;
    private PlayerController pc;
    public GameObject arrowPrefab;

    public Transform firepoint1;
    public Transform firepoint2;
    public Transform firepoint3;
    public Transform firepoint4;

    private float shootDelay = 0.45f;
    private float attackTime = 0f;

    public Animator ani;

    static public int arrows;

    public Texture2D bowCursor;
    public Texture2D normalCursor;
    public Texture2D noArrow;


    // Start is called before the first frame update
    void Start()
    {
        arrows = 0;
        isBow = false;
        player = transform.parent.gameObject;
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Switch"))
        {
            isBow = !isBow;
            if (isBow)
            {
                Cursor.SetCursor(bowCursor, UnityEngine.Vector2.zero, CursorMode.ForceSoftware);
            }
            else
            {
                Cursor.SetCursor(normalCursor, UnityEngine.Vector2.zero, CursorMode.ForceSoftware);
            }
        }
        if (isBow && Input.GetButtonDown("Fire1"))
        {
            Prep();
        }
        if (isBow && Input.GetButtonUp("Fire1"))
        {
            if(Time.time > attackTime)
            {
                if(arrows > 0)
                {
                    Shoot();
                }
            }
            Revert();
        }
        if(isBow && arrows < 1)
        {
            Cursor.SetCursor(noArrow, UnityEngine.Vector2.zero, CursorMode.ForceSoftware);
        }

    }



    void Prep()
    {
        player.GetComponent<PlayerController>().speed = 0.5f;
        attackTime = Time.time + shootDelay;
        ani.SetBool("isShoot", true);
    }


    void Shoot()
    {
            if (pc.position == 1)
            {
                Instantiate(arrowPrefab, firepoint1.position, firepoint1.rotation);
            }
            else if (pc.position == 2)
            {
                Instantiate(arrowPrefab, firepoint2.position, firepoint2.rotation);
            }
            else if (pc.position == 3)
            {
                Instantiate(arrowPrefab, firepoint3.position, firepoint3.rotation);
            }
            else if (pc.position == 4)
            {
                Instantiate(arrowPrefab, firepoint4.position, firepoint4.rotation);
            }
        arrows--;
    }

    void Revert()
    {
        player.GetComponent<PlayerController>().NormalSpeed();
        ani.SetBool("isShoot", false);
    }


}
