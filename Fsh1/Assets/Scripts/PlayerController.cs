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
}
