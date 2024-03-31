using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public Animator animator;
    //public Sprite eyes;
    public GameObject eyes;
     public Color visible;
    public Color invisible;

    private void Start()
    {
        eyes.GetComponent<SpriteRenderer>().enabled = false;
        //eyes.GetComponent<SpriteRenderer>().color = invisible;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit chest");
        animator.SetBool("ChestOpen", true);
        StartCoroutine(EyesVisible());
    }

    private IEnumerator EyesVisible()
    {
        yield return new WaitForSeconds(1.5f);
        eyes.GetComponent<SpriteRenderer>().enabled = true;
        //eyes.SetActive(true);
        //eyes.GetComponent<SpriteRenderer>().enabled = true;
        //eyes.GetComponent<SpriteRenderer>().color = visible;
    }
}
