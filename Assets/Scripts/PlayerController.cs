//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody theRB;
    [SerializeField]

    //Walk
    private float moveSpeed, jumpForce;
    private Vector2 moveInput;

    //Jump
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private Transform groundPoint;

    private bool isGrounded;
    private Vector3 extraGrav;

    //Messing with the Sprite
    [SerializeField]    
    private SpriteRenderer theSR;
    [SerializeField]
    private Animator flipAnim;

    //For Interactables
    private Interactable interactable;
    private Interactable focus;

    void Start()
    {
        isGrounded = true;
        extraGrav = new Vector3(0f, -19.6f, 0f);
    }

    void Walk()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();  

        if(moveInput.magnitude > 0)
        {
            RemoveFocus();
        }
        theRB.velocity = new Vector3(moveInput.x * moveSpeed, theRB.velocity.y, moveInput.y * moveSpeed);
    }

    void Jump()
    {
        //Check if player is on ground
        RaycastHit hit;
        if(Physics.Raycast(groundPoint.position, Vector3.down,out hit, .3f, whatIsGround))
        {
            isGrounded = true;

        }else
        {
            isGrounded = false;
        }

        //Jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            theRB.velocity += new Vector3(0f , jumpForce, 0f);
        }

        //Add extra gravity to make the jump more snappy
        if(!isGrounded)
        {
            theRB.AddForce(extraGrav);
        }
    }

    void Flip()
    {
        //Flip image with animation if going in the opposite direction
        if(!theSR.flipX && moveInput.x < 0)
        {
            theSR.flipX = true;
            flipAnim.SetTrigger("Flip");
        } else if (theSR.flipX && moveInput.x > 0)
        {
            theSR.flipX = false;
            flipAnim.SetTrigger("Flip");
        }
    }
    void Update()
    {
        Walk();
        Jump();
        Flip();
        Interact();        
    }

    void Interact()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(interactable!= null)
            {
                SetFocus(interactable);
            }      
        }

    }

    //Handles interactions with interactables
    private void OnTriggerEnter(Collider other)
    {
        interactable = other.GetComponent<Interactable>();
        
    }

    private void OnTriggerExit(Collider other)
    {
        interactable = null;
        
    }

    void SetFocus (Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if(focus != null)
            {
                focus.OnDefocused();
            }
            focus = newFocus;
        }
        newFocus.OnFocused(transform);

    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
        
    }
}
