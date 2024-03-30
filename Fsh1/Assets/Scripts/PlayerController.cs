using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 movement;
    [SerializeField] private float jumpForce;
    private Vector2 lookDirection = new Vector2(1, 0);
    private Vector2 lookDirection2 = new Vector2(-1, 0);
    public Animator animator;
    private bool isGrounded;
    //private Vector2 jumpDirection;

    // Start is called before the first frame update
    void Start()
    {
        InitValues();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), 0);
        MoveCharacter(movement);
        Jump();
        NPCTextBox();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
        }
    }
    

    private void InitValues()
    {
        rb = GetComponent<Rigidbody2D>();
        //jumpDirection = new Vector2(0, 5);
    }

    private void MoveCharacter(Vector2 _direction)
    {
        //Too slide-y
        rb.AddForce(Vector2.right * _direction * speed);

        
        #region ANIM TEST
        if(_direction.x > 0)
        {
            animator.SetBool("MoveLeft", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("FaceLeft", false);
        }
        else if(_direction.x < 0) 
        {
            animator.SetBool("MoveLeft", true);
            animator.SetBool("IsIdle", false);
            animator.SetBool("FaceLeft", true);
        }
        else if(_direction.x == 0)
        {
            animator.SetBool("IsIdle", true);
            animator.SetBool("MoveLeft", false);
            
        }
        #endregion

        //animator.SetFloat("Test", _direction.x);
        //animator.SetFloat("Test", newXPos);



    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("IsJumping", true);
        }
           
    }

    private void NPCTextBox()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            
            RaycastHit2D hit = Physics2D.Raycast(rb.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC")); 
            {
                
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if(character != null)
                {
                    if(character.inDialog == false)
                    {
                        character.DisplayDialog();
                    } 
                    else if(character.inDialog == true)
                    {
                        ;
                    }
                    
                    
                }
            }

            RaycastHit2D hit1 = Physics2D.Raycast(rb.position + Vector2.up * 0.2f, lookDirection2, 1.5f, LayerMask.GetMask("NPC")); 
            if (hit1.collider != null)
            {

                NonPlayerCharacter character = hit1.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    if (character.inDialog == false)
                    {
                        character.DisplayDialog();
                    }
                    else if (character.inDialog == true)
                    {
                        ;
                    }

                }
            }
        }
    }
}
