using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{

    public int health;


    //movement and object vars
    public Transform Player;
    public Collider MyHitbox;
    public float speed;
    public float gravity = -9.81f;
    public Vector3 velocity;
    public Vector3 moveDelta;
    public float groundDistance = 0.4f;
    public LayerMask mask;
    public Transform groundCheck;
    private bool isGrounded;
    private CharacterController characterController;
    public bool isInChaseZone;
    public Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        MyHitbox = GetComponent<Collider>();
        characterController = GetComponent<CharacterController>();
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (health == 0)
        {
            Destroy(gameObject);
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, mask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }




        if (isGrounded) {
           
            if (Vector3.Distance(Player.position, transform.position) < 10)
            {
                isInChaseZone = true;
            }
            else
            {
                isInChaseZone = false;
            }
            if (isInChaseZone)
            {
                velocity = (Player.position - transform.position).normalized;
            }
            else
            {
                velocity = (origin - transform.position).normalized;
            }
            

        }
        var rotation = Quaternion.LookRotation(Player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
        //Delta y =1/2g.t*t
        velocity.y += gravity * Time.deltaTime * Time.deltaTime;



        characterController.Move(velocity*speed);
    }




    public virtual void takeDamage(int damage)
    {
        health = health - damage;
    }

    //input should be normalized
   
}
