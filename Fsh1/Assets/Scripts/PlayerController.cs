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

    private void FixedUpdate()
    {
       //MoveCharacter(movement);
        
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

        
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
