using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 5f;
    public GameObject dialogBox;
    private float timerDisplay;

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayDialog()
    {
        StartCoroutine(TimeDialogue());
    }

    public IEnumerator TimeDialogue()
    {
        dialogBox.SetActive(true);

        yield return new WaitForSeconds(displayTime);

        dialogBox.SetActive(false);
    }
}
