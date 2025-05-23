using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.TextCore.Text;
using System.Linq.Expressions;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 5f;
    public GameObject dialogBox;
    public string[] dialog;
    public TextMeshProUGUI dialogText;
    public float textSpeed;
    private int index = 0;
    public bool inDialog = false;

    // Start is called before the first frame update
    void Start()
    {
        
        dialogBox.SetActive(false);
        dialogText.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        //if(dialogBox.activeInHierarchy == true)
        //{
            /*if(Input.GetKeyDown(KeyCode.X) && index > 0)
            {
                
                NextLine();
            }*/

            if(Input.GetKeyDown(KeyCode.X) && inDialog)
            {
                if(dialogText.text == dialog[index])
                {
                Debug.Log("x in dialog");
                    NextLine();
                }
               /* else
                {
                Debug.Log("what does this even do");
                    StopAllCoroutines();
                    dialogText.text = dialog[index];
                }*/
            }
       // }
    }

    public void DisplayDialog()
    {
        StartDialog();
        
    }

    public void StartDialog()
    {
        //index = 0;
        StartCoroutine(TypeString());
        //index++;
    }

    public void NextLine()
    {
        
        if (index < dialog.Length - 1) 
        {
            Debug.Log(index);
            index++;
            dialogText.text = string.Empty;
            StartCoroutine(TypeString());
        }
        else if (index == dialog.Length - 1)
        {
            Debug.Log("End next line");
            //StartCoroutine(TimeDialogue());
            TimeDialogue();
        }
    }
    public void TimeDialogue()
    {

        Debug.Log("Timedialogue");
        //index++;
        dialogText.text = string.Empty;
        //StartCoroutine(TypeString());
        //yield return new WaitForSeconds(displayTime);
        index = 0;

        inDialog = false;
        dialogBox.SetActive(false);
    }

    public IEnumerator TypeString()
    {
        Debug.Log("In type string");
        dialogBox.SetActive(true);
        inDialog = true;
        foreach (char c in dialog[index].ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }


    }

    
}
