using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // DontDestroyOnLoad(this.gameObject);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("2_Game");
        //Maybe player walks down and then this is triggered?
    }

    public void LoadBeginingCutscene()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene("1_BedroomCutscene");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("3_Credits");
        ReloadMenu();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("0_MainMenu");
    }

    public void ReloadMenu()
    {
        StartCoroutine(DoubleReload());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("4_GameOver");
        ReloadMenu();
    }

    public IEnumerator DoubleReload()
    {
        Debug.Log("In reload");
        yield return new WaitForSeconds(5);
        Debug.Log("After reload");
        SceneManager.LoadScene("0_MainMenu");
    }
}
