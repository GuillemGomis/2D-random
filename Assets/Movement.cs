using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce;
    public bool IsGrounded = false;
    private bool facingRight = true;
    private float moveInput;
    private Rigidbody2D rb;
    private int extraJump;
	
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}

    
    void FixedUpdate()
    {
        
        moveInput = Input.GetAxis("Horizontal");
        
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);


        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }

        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }


    void Update ()
    {
        if (IsGrounded == true)
        {
            extraJump = 1;
        }


        if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        }
      
        


    }

   
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
       
    }
        

}
