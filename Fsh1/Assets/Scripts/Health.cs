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
                    if (i - 1 != -1)
                    {
                        currentPlatform = platforms[i - 1];
                        
                        transform.position = new Vector2(currentPlatform.transform.position.x, currentPlatform.transform.position.y + 1);
                        Debug.Log("Platform " + currentPlatform.transform.position.x);
                        Debug.Log("Player = " + transform.position.x);
                        break;
                    }
                    else
                    {
                        break;
                    }
                    
                }
                else
                {
                    continue;
                }
            }

        }
    }
}
