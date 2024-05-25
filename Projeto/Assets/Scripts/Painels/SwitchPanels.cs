using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPanels : MonoBehaviour
{
    [Header("Paineis e canvas")]
    [Tooltip("Variáveis para telas")]
    public Canvas HUD;
    public GameObject pauseMenu;
    public GameObject panelUI;
    public GameObject dialogueBox;
    public GameObject quests;
    public GameObject market;
    public GameObject gameOver;
    private bool isGamePaused;
    // Start is called before the first frame update
    void Start()
    {
        HUD.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !market.transform.gameObject.activeSelf && !isGamePaused){
            PauseMenuOn();
        }else if(Input.GetKeyDown(KeyCode.Escape) && !market.transform.gameObject.activeSelf && isGamePaused){
            PauseMenuOff();
        }
        
    }
    public void PauseMenuOn(){
        pauseMenu.SetActive(true);
        TogglePauseState(true);
        quests.transform.gameObject.SetActive(false);
        dialogueBox.transform.gameObject.SetActive(false);
    }
    public void PauseMenuOff(){
        pauseMenu.SetActive(false);
        TogglePauseState(false);
        quests.transform.gameObject.SetActive(true);
        dialogueBox.transform.gameObject.SetActive(true);
    }
    private void TogglePauseState(bool pause)
    {
        if (pause){
            Time.timeScale = 0;
            isGamePaused = true;
        }else{
            Time.timeScale = 1;
            isGamePaused = false;
        }
    }
}
