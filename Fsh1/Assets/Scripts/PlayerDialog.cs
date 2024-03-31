using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDialog : MonoBehaviour
{
    public GameObject dialogBox;
    public string dialog;
    public TextMeshProUGUI dialogText;
    public float textSpeed;
    private int index = 0;
    public bool inDialog = false;
    public NonPlayerCharacter character;

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        dialogText.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && inDialog)
        {
            if (dialogText.text == dialog)
            {
                Debug.Log("x in dialog");
                TimeDialogue();
                //NextLine();
            }
        }
    }

    public void DisplayDialog()
    {
        StartDialog();

    }

    public void StartDialog()
    {

        StartCoroutine(TypeString());

    }

    

    public void TimeDialogue()
    {

        Debug.Log("Timedialogue");
        dialogText.text = string.Empty;
        index = 0;

        inDialog = false;
        dialogBox.SetActive(false);
        character.DisplayDialog();
    }

    public IEnumerator TypeString()
    {
        Debug.Log("In type string");
        dialogBox.SetActive(true);
        inDialog = true;
        foreach (char c in dialog.ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }


    }

    //Player dialog restarts right after npc dialog stops, needs to not :)
}
