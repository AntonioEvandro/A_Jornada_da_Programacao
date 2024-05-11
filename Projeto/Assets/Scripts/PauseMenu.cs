using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Transform pauseMenu;
    private bool isGamePaused = false;
    public GameObject Quests;
    public GameObject Market;
    public GameObject Dialog;

    // Start is called before the first frame update
    void Start()
    {
        if (pauseMenu.gameObject.activeSelf)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Market.transform.gameObject.activeSelf)
        {
            TogglePauseState();
        }

        // Block input when the game is paused
        if (isGamePaused)
        {
            // Optionally, you can add additional code here to handle other paused state actions
            return;
        }
    }

    public void ResumeGame()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
        Quests.transform.gameObject.SetActive(true);
        Dialog.transform.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
        Quests.transform.gameObject.SetActive(false);
        Dialog.transform.gameObject.SetActive(false);
    }

    private void TogglePauseState()
    {
        if (isGamePaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
}
