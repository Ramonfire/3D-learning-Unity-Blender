using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{


    CharacterController characterController;
    public float speed;
    public float gravity = -9.81f;
    public  Vector3 velocity;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask mask;
    private bool isGrounded;
    public Animator characterAnimator;
    public AudioSource jump;
    public AudioSource run;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        speed = 5f;
        jumpHeight = 2.0f;
        characterAnimator = GetComponentInChildren<Animator>();
    }


    private void LateUpdate()
    {
        if (Input.GetButtonDown("Reset"))
        {
            returnToCheckPoint();
        }
    }

    void Update()
    {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance,mask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            if (!run.isPlaying && isGrounded)
            {
                run.Play();
            }
        }



        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            jump.Play();
            run.Stop();
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);

        }

        //Delta y =1/2g.t*t
        velocity.y += gravity * Time.deltaTime;

        if (x != 0 || z != 0 )
        {
            characterAnimator.SetTrigger("run");
        }
        if (x == 0 && z == 0 && velocity.y < 0)
        {
            characterAnimator.SetTrigger("idle");
            run.Stop();
            jump.Stop();
        }


        characterController.Move(velocity * Time.deltaTime);

        

    }




    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("bouncy"))
        {

            velocity.y = Mathf.Sqrt(3*jumpHeight * -2 * gravity);

        }
        if (hit.gameObject.CompareTag("danger"))
        {
            //reload to checkpoint 
            Debug.Log("Danger!");
        }
        if (hit.gameObject.CompareTag("Checkpoint"))
        {

            GameManager.instance.Checkpoint = int.Parse(hit.gameObject.name);
        }
        if (hit.gameObject.CompareTag("Border"))
        {
            GameManager.instance.Checkpoint = 0;
            returnToCheckPoint();
        }
        else
        {
            return;
        }
    }


    public void returnToCheckPoint()
    {
        transform.position = GameManager.instance.checkpoints[GameManager.instance.Checkpoint].position + new Vector3(0, 0.32f, 0);
    }




}
