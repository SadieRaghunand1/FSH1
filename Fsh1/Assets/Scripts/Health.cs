using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 5;
    public GameObject[] platforms;
    [SerializeField] GameObject currentPlatform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.layer == 7)
        {
            currentPlatform = collision.gameObject;
        }
        
        if(collision.gameObject.layer == 6)
        {
           
            health -= 1;

            for(int i = 0; i < platforms.Length; i++)
            {
                if (platforms[i] == currentPlatform)
                {
                    currentPlatform = platforms[i - 1];
                    //transform.Translate()
                }
            }

        }
    }
}
