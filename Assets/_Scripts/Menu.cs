using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnRestartButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnMainButton()
    {
        SceneManager.LoadScene("TitleScreen");
    }




}
