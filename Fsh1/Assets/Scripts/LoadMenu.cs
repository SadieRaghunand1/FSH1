using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "3_Credits" || SceneManager.GetActiveScene().name == "4_GameOver")
        {
            ReloadMenu();
        }
    }

   

    public void ReloadMenu()
    {
        StartCoroutine(DoubleReload());
    }

    public IEnumerator DoubleReload()
    {
        Debug.Log("In reload");
        yield return new WaitForSeconds(5);
        Debug.Log("After reload");
        SceneManager.LoadScene("0_MainMenu");
    }

}
