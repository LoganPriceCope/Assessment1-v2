using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    // Variables

    Rigidbody2D rb;
    RayCastScript rc;
    Animator anim;
    SpriteRenderer sr;
    private bool isJumping;
    private bool isSprinting;
    public CoinScript cs;
    bool l, r, c;

    // Start

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rc = gameObject.AddComponent<RayCastScript>();
        isSprinting = false;
    }

    public float jumpHeight = 5f;
    public float walkSpeed = 1f;
    public float MaxDoubleJumps = 2f;
    public float currentDoubleJumps = 0f;

    // Main

    void Update()
    {
        anim.SetBool("walk", false);
        
 

        
        l = rc.DoRayCollisionCheck(0, 0);
        r = rc.DoRayCollisionCheck(-0.15f, 0);
        c = rc.DoRayCollisionCheck(0.15f, 0);

        // Jumping
        if ((l == true) || (r == true) || (c == true) || currentDoubleJumps < MaxDoubleJumps)
        {
            if (Input.GetKeyDown("space"))
            {
                anim.SetBool("jump", true);
                rb.AddForce(new Vector3(0, 7, 0), (ForceMode2D)ForceMode.Impulse);
                isJumping = true;
                currentDoubleJumps = currentDoubleJumps + 1f;
            }
            else if (currentDoubleJumps >= MaxDoubleJumps)
            {
                currentDoubleJumps = 0f;
            }
        }

        // Sprint
        if (Input.GetKey("left shift")== true && (isSprinting == false))
        {
            walkSpeed = walkSpeed * 3f;
            isSprinting = true;
            Console.WriteLine("Started sprinting");
        }
        if (Input.GetKey("left shift") == false)
        {
            walkSpeed = 1f;
            isSprinting = false;
            Console.WriteLine("Finished sprinting");
        }

        // Left

        if (Input.GetKey("a") == true)
        {
            transform.position = new Vector2(transform.position.x - (walkSpeed * Time.deltaTime), transform.position.y);
            sr.flipX = true;

            if (isJumping == false)
            {
                anim.SetBool("walk", true);
            }
            else
            {
                walkSpeed = 6f;
            }
        }

        // Right

        if (Input.GetKey("d") == true)
        {
            transform.position = new Vector2(transform.position.x + (walkSpeed * Time.deltaTime), transform.position.y);
            sr.flipX = false;

            if (isJumping == false)
            {
                anim.SetBool("walk", true);
            }
            else
            {
                walkSpeed = 6f;
            }
        }

        CheckForLanding();


    }

    void CheckForLanding()
    {
        if ((rb.velocity.y <= 0) && (isJumping==true))
        {
            if ((l == true) || (r == true) || (c == true))
            {
                anim.SetBool("jump", false);
                isJumping = false;
                currentDoubleJumps = 0f;
                if (isSprinting == true)
                {
                    walkSpeed = 3f;
                }
               else
                {
                    walkSpeed = 1f;
                }
                
            }

        }
            
        

    }



    void OnTriggerEnter2D(Collider2D powerUps)
    {
        if (powerUps.gameObject.CompareTag("Coin"))
        {
            Destroy(powerUps.gameObject);
            cs.coinCount++;
        }
        else if (powerUps.gameObject.CompareTag("DoubleJumpBoost"))
        {
            Destroy(powerUps.gameObject);
            MaxDoubleJumps = MaxDoubleJumps + 1;
        }
    }


    
}




       /* if (isJumping == false)
        {
            // check for jump key pressed

            // Jump
            if ((c == true) || (l == true) || (r == true))
            {
                if (Input.GetKeyDown("space"))
                {
                    anim.SetBool("Jump", true);
                    rb.AddForce(new Vector3(0, 5, 0), (ForceMode2D)ForceMode.Impulse);
                    isJumping = true;
                }
            }
        }
        else 
        {
            // check for player landing
            if( rb.velocity.y <= 0 )
            {
                isJumping = false;
                anim.SetBool("Jump", false);

            }
        }
    }
}
       */
