using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    public float distanceToPlayer;
    private float distanceToBridge;

    public Transform bridge;
    public Transform endPoint;




    public Animator ani;

    public bool canMove = true;
    public bool end = false;

    // Start is called before the first frame update
    void Start()
    {
        bridge = FindObjectOfType<BridgeScript>().transform;
        endPoint = FindObjectOfType<EndPointScript>().transform;
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            distanceToPlayer = (target.position - transform.position).sqrMagnitude;
            distanceToBridge = (target.position - bridge.position).sqrMagnitude;
        }
        
        if (target && canMove && distanceToPlayer < 50f && !end)
        {
            FollowPlayer();
            Animate(target);
        }
        else if(target && canMove && distanceToPlayer >= 50f && !end)
        {
            FollowBridge();
            Animate(bridge);
        }
        else if(end && canMove)
        {
            FollowEnd();
        }
        else if (!target)
        {
            ani.SetFloat("Speed", 0f);
        }
        
    }

    void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void Animate(Transform target)
    {
        ani.SetFloat("Horizontal", (target.position.x - transform.position.x));
        ani.SetFloat("Vertical", (target.position.y - transform.position.y));
        ani.SetFloat("Speed", speed);
    }

    void FollowBridge()
    {
        transform.position = Vector3.MoveTowards(transform.position, bridge.position, speed * Time.deltaTime);
    }

    void FollowEnd()
    {
        Vector3 endPosition = new Vector3(transform.position.x, endPoint.position.y, 0f);
        transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
    }

}
