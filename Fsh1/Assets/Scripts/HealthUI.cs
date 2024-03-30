using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Health healthInt;
    public int healthVal;

    public Sprite[] healthImgs;
    public Image healthUIImg;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetHealthUI();
    }

    private void SetHealthUI()
    {
        healthVal = healthInt.health;
        
        if(healthVal == 5)
        {
            healthUIImg.sprite = healthImgs[0];
        }
        else if(healthVal == 4)
        {
            healthUIImg.sprite = healthImgs[1];
        }
        else if (healthVal == 3)
        {
            healthUIImg.sprite = healthImgs[2];
        }
        else if (healthVal == 2)
        {
            healthUIImg.sprite = healthImgs[3];
        }
        else if (healthVal == 1)
        {
            healthUIImg.sprite = healthImgs[4];
        }
        else if (healthVal == 0)
        {
            healthUIImg.sprite = null;
            healthUIImg.enabled = false;
            
        }
    }
}

