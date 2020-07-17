using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void OnNextClick()
    {
        Application.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void OnQuitClick()
    {
        Application.Quit();
    }

    public void OnMainMenuClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnCreditMenuClick()
    {
        SceneManager.LoadScene(7);
    }
}