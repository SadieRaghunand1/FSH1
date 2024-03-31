using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("2_Game");
        //Maybe player walks down and then this is triggered?
    }

    public void LoadBeginingCutscene()
    {
        SceneManager.LoadScene("1_BedroomCutscene");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("3_Credits");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("0_MainMenu");
    }

    public IEnumerator ReloadMenu()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("0_MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
