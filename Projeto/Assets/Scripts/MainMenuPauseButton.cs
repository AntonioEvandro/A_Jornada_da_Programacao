using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void LoadMainMenuScene()
    {
        // Load the MainMenu scene by its name
        SceneManager.LoadScene("Menu Principal");
    }
}
