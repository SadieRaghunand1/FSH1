using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTForcepatrolpointpos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.layer == 10)
        {
            transform.position = new Vector2(transform.position.x + 7f, transform.position.y - 63.09f);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
