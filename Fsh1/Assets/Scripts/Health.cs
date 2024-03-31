using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health = 5;
    public GameObject[] platforms;
    [SerializeField] GameObject currentPlatform;
    public LoadManager manager;

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

        if (health == 0)
        {
            manager.GameOver();
        }
    }
}
