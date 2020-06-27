//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody theRB;
    public float moveSpeed, jumpForce;

    private Vector2 moveInput;

    public LayerMask whatIsGround;
    public Transform groundPoint;


    private bool isGrounded;
    private Vector3 extraGrav;

    
    public SpriteRenderer theSR;
    public Animator flipAnim;

    void Start()
    {
        isGrounded = true;
        extraGrav = new Vector3(0f, -5f, 0f);
    }

    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();  
  

        RaycastHit hit;
        if(Physics.Raycast(groundPoint.position, Vector3.down,out hit, .3f, whatIsGround))
        {
            isGrounded = true;

        }else
        {
            isGrounded = false;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            theRB.velocity += new Vector3(0f , jumpForce, 0f);
        }

        if(!theSR.flipX && moveInput.x > 0)
        {
            theSR.flipX = true;
            flipAnim.SetTrigger("Flip");
        } else if (theSR.flipX && moveInput.x < 0)
        {
            theSR.flipX = false;
            flipAnim.SetTrigger("Flip");
        }
    }

    void FixedUpdate()
    {
        theRB.velocity = new Vector3(moveInput.x * moveSpeed, theRB.velocity.y, moveInput.y * moveSpeed);

        if(!isGrounded)
        {
            theRB.AddForce(extraGrav);
        }
    }
}
