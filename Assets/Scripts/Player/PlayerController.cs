using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D player;
    [Header("Movement")]
    public float speed;
    public float normalSpeed;
    public Vector2 movement;
    [Header("Animation")]
    public Animator ani;
    private float isWalk;

    public int position;

    public bool canMove;


    //hi this wawd a d

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        speed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Animate();
        /*
        if (Input.anyKeyDown)
        {
            UpdatePosition();
        }
        */
        UpdatePosition();
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            player.MovePosition(player.position + movement * speed * Time.fixedDeltaTime);
        }
        
    }

    void Animate()
    {
        if(movement.sqrMagnitude > 0)
        {
            isWalk = 1;
        }
        else
        {
            isWalk = 0;
        }
        if(movement != Vector2.zero)
        {
            ani.SetFloat("Horizontal", movement.x);
            ani.SetFloat("Vertical", movement.y);
        }
        ani.SetFloat("Speed", isWalk);
    }

    void UpdatePosition()
    {
        if(movement.y == 1)
        {
            position = 1;
        }
        else if(movement.y == -1)
        {
            position = 3;
        }
        else if(movement.x == 1)
        {
            position = 2;
        }
        else if(movement.x == -1)
        {
            position = 4;
        }
    }
    
    public void NormalSpeed()
    {
        speed = normalSpeed;
    }
}
