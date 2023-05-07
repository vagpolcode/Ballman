using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    private int run = 1;
    private int SecondJump = 0;
    public ParticleSystem CoinFlash;
    public ParticleSystem CherryFlash;
    public ParticleSystem DotFlash;
    public ParticleSystem PowerFlash;
    public ParticleSystem TakeDamage;
    public ParticleSystem HoleFlash;
    public ParticleSystem LifePointFlash;

    public Transform teleportTarget;
    public Transform teleportTarget1;
    public Transform teleportTarget2;
    public Transform teleportTarget3;
    public Transform teleportTarget4;
    public Transform teleportTarget5;

    public GameObject Player;

    public AudioSource JumpSound;
    public AudioSource TakeDamageSound;
    public AudioSource HoleSound;
    public AudioSource CoinSound;
    public AudioSource PowerSound;
    public AudioSource LifePointSound;
 
    
    public bool disabled = false;

    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public int scorecoin = 0;
    public int points = 100;
    public int level = 1;
    public int live = 1;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {   
        if(GameManager.Instance.Lives > 0 && GameManager.Instance.Score != 84500)
        {
            controller.enabled = true;
        }
         if(GameManager.Instance.Lives < 0)
        {
            GameManager.Instance.Lives = 0;
        }
         if(GameManager.Instance.Lives == 0 || GameManager.Instance.Score == 84500 || GameManager.Instance.Finish == 1)
        {
            controller.enabled = false;
        }


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * run * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {   
            JumpSound.Play();
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            
        }
        

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            run = 2 ;   
        }
        else if(isGrounded)
        {
            run = 1 ; 
        }
      
        if(Input.GetButtonDown("Jump") && SecondJump==0 )
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                SecondJump = 1;
            }
        
       if(isGrounded)
        {   
            SecondJump = 0; 
        }

    }

    public void OnTriggerEnter(Collider other)
        {
           

        if(other.gameObject.layer == 9)
            {
           Destroy(other.gameObject);
           GameManager.Instance.Score += points;
           scorecoin++ ;
           CoinFlash.Play();
           CoinSound.Play();  
            } 

         if(other.gameObject.layer == 6)
            {
                GameManager.Instance.Lives -= 3*live;
                scorecoin++ ;
                TakeDamage.Play();
                TakeDamageSound.Play();
               
            } 

         if(other.gameObject.layer == 7)
            {
                GameManager.Instance.Lives -= 10*live;
                scorecoin++ ;
                TakeDamage.Play();
                TakeDamageSound.Play();

            } 

             if(other.gameObject.layer == 25)
            {
                GameManager.Instance.Lives -= 2*live;
                scorecoin++ ;
                TakeDamage.Play();
                TakeDamageSound.Play();

            } 

             if(other.gameObject.layer == 26)
            {
                GameManager.Instance.Lives -= 1*live;
                scorecoin++ ;
                TakeDamage.Play();
                TakeDamageSound.Play();

            } 





        if(other.gameObject.layer == 10)
            {
                GameManager.Instance.Lives -= live;
                scorecoin++ ;
                TakeDamage.Play();
                TakeDamageSound.Play();

            } 

        if(other.gameObject.layer == 11)
            {
                controller.enabled = false;
                Player.gameObject.transform.position = teleportTarget.position;
                controller.enabled = true;
                HoleFlash.Play();
                HoleSound.Play();
                GameManager.Instance.Lives -= live;
            } 

        if(other.gameObject.layer == 12)
            {
                controller.enabled = false;
                Player.gameObject.transform.position = teleportTarget1.position;
                controller.enabled = true;
                HoleFlash.Play();
                HoleSound.Play();
            } 

        if(other.gameObject.layer == 13)
            {
                controller.enabled = false;
                Player.gameObject.transform.position = teleportTarget2.position;
                controller.enabled = true;
                HoleFlash.Play();
                HoleSound.Play();
            } 

        if(other.gameObject.layer == 14)
            {
                controller.enabled = false;
                Player.gameObject.transform.position = teleportTarget3.position;
                controller.enabled = true;
                HoleFlash.Play();
                HoleSound.Play();
            } 

        if(other.gameObject.layer == 15)
            {
                controller.enabled = false;
                Player.gameObject.transform.position = teleportTarget4.position;
                controller.enabled = true;
                HoleFlash.Play();
                HoleSound.Play();
            }

        if(other.gameObject.layer == 16)
            {
                controller.enabled = false;
                Player.gameObject.transform.position = teleportTarget5.position;
                controller.enabled = true;   
                HoleFlash.Play();   
                HoleSound.Play();  
        }  




        if(other.gameObject.layer == 21)
            {
           Destroy(other.gameObject);
           GameManager.Instance.Score += 5*points;
           scorecoin++ ;
           CherryFlash.Play();
           CoinSound.Play();  
            } 

        if(other.gameObject.layer == 22)
            {
           Destroy(other.gameObject);
           GameManager.Instance.Score += 3*points;
           scorecoin++ ;
           DotFlash.Play();
           CoinSound.Play();  
            } 


        if(other.gameObject.layer == 20)
            {
           Destroy(other.gameObject);
           GameManager.Instance.Score += 10*points;
           scorecoin++ ;
           PowerFlash.Play();
           PowerSound.Play();  
            } 

         if(other.gameObject.layer == 23)
            {
           Destroy(other.gameObject);
           GameManager.Instance.Lives += 1*live;
           
           LifePointFlash.Play();
           LifePointSound.Play();  
            } 

        if(other.gameObject.layer == 30)
            {
           
           GameManager.Instance.Score += 5*points;
           GameManager.Instance.Finish = 1;
             
            } 



        }






}
