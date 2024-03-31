using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.TextCore.Text;


public class CutsceneDialog : MonoBehaviour
{
    public string[] startGameDialog;
    public string[] endGameDialog;
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public int index = 0;
    public float textSpeed;
    public int startGame;
    public LoadManager manager;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "1_BedroomCutscene")
        {
            StartCoroutine(TypeStringStartG());
            startGame = 0;
        }
        else
        {
            index = 0;
            startGame = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && startGame == 0)
        {
            //Debug.Log("Input");
            if (dialogText.text == startGameDialog[index])
            {
                index++;

                if(index != startGameDialog.Length)
                {
                    StartCoroutine(TypeStringStartG());
                } 
                else if(index <= startGameDialog.Length)
                {
                    dialogBox.SetActive(false);
                    index = 0;
                }
                
                
            }
        } 
        else if(Input.GetKeyDown(KeyCode.X) && startGame == 2)
        {
            if (dialogText.text == endGameDialog[index])
            {
                index++;

                if (index != endGameDialog.Length)
                {
                    StartCoroutine(TypeStringStartE());
                }
                else if (index <= endGameDialog.Length)
                {
                    dialogBox.SetActive(false);
                    manager.LoadCredits();
                }


            }
        }
    }

    public IEnumerator TypeStringStartG()
    {
        Debug.Log("In type string");
        dialogBox.SetActive(true);
        //inDialog = true;
        //character.inDialog = true;
        dialogText.text = string.Empty;
        foreach (char c in startGameDialog[index].ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

       


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 11)
        {
            startGame = 2;
            StartCoroutine(TypeStringStartE());
            
        }
    }

    public IEnumerator TypeStringStartE()
    {
        Debug.Log(index);
        Debug.Log("In type string");
        dialogBox.SetActive(true);
        //inDialog = true;
        //character.inDialog = true;
        dialogText.text = string.Empty;
        foreach (char c in endGameDialog[index].ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }




    }
}
