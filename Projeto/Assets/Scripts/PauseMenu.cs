using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Transform pauseMenu;
    private bool isGamePaused = false;
    public GameObject player;

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
        if (Input.GetKeyDown(KeyCode.Escape))
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
    }

    public void PauseGame()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
        player.gameObject.GetComponent<HeartSystem>().CloseQuest();
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
