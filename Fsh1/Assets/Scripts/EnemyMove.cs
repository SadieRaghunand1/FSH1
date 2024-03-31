using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject[] patrolPoints;
    public GameObject nextPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPoint();
        Patrol();
    }

    private void MoveToPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, nextPoint.transform.position, speed * Time.deltaTime);
    }

    private void Patrol()
    {
        if(transform.position.x == nextPoint.transform.position.x && transform.position.y == nextPoint.transform.position.y)
        {
            Debug.Log("Same pos as next pt");

            for(int i = 0; i < patrolPoints.Length; i++)
            {
                if (patrolPoints[i] == nextPoint)
                {
                   if(i != patrolPoints.Length - 1)
                    {
                        nextPoint = patrolPoints[i + 1];
                        break;
                    } 
                    else if(i == patrolPoints.Length -1)
                    {
                        nextPoint = patrolPoints[0];
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
