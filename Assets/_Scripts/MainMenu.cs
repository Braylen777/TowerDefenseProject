using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add me!!
public class MainMenu : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }







}
