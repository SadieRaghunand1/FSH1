using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 5f;
    public GameObject dialogBox;
    public string[] dialog;
    public TextMeshProUGUI dialogText;
    public float textSpeed;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        dialogText.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayDialog()
    {
        StartDialog();
        
    }

    public void StartDialog()
    {
        index = 0;
        StartCoroutine(TypeString());
    }

    public void NextLine()
    {
        if(index < dialog.Length - 1) 
        {
            index++;
            dialogText.text = string.Empty;
            StartCoroutine(TypeString());
        }
        else
        {
            StartCoroutine(TimeDialogue());
        }
    }
    public IEnumerator TimeDialogue()
    {
        

        yield return new WaitForSeconds(displayTime);

        dialogBox.SetActive(false);
    }

    public IEnumerator TypeString()
    {
        dialogBox.SetActive(true);
        foreach (char c in dialog[index].ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
