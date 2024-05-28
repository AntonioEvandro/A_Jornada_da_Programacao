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
    public Transform gameOver;
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
        }else if(Input.GetKey(KeyCode.Escape) && market.transform.gameObject.activeSelf){
            MarketOff();
        }
        //esses if's de mercado abaixo é apenas para desenvolvimento, apague/comente depois que der certo
        if (Input.GetKeyDown(KeyCode.M) && !pauseMenu.transform.gameObject.activeSelf && !isGamePaused){
            MarketOn();
        }else if(Input.GetKeyDown(KeyCode.M) && !pauseMenu.transform.gameObject.activeSelf && isGamePaused){
            MarketOff();
        }
        
    }
    //Funções para mostrar/ocultar tela de pausa
    public void PauseMenuOn(){
        pauseMenu.SetActive(true);
        TogglePauseState(true);
        quests.transform.gameObject.SetActive(false);
        dialogueBox.transform.gameObject.SetActive(false);
        panelUI.SetActive(false);
        HUD.enabled = false;
    }
    public void PauseMenuOff(){
        pauseMenu.SetActive(false);
        TogglePauseState(false);
        quests.transform.gameObject.SetActive(true);
        dialogueBox.transform.gameObject.SetActive(true);
        panelUI.SetActive(true);
        HUD.enabled = true;
    }
    // Funçoes para mostrar/ocultar tela do mercado
    public void MarketOn(){
        market.SetActive(true);
        TogglePauseState(true);
        panelUI.SetActive(false);
        HUD.enabled = false;
    }
    public void MarketOff(){
        market.SetActive(false);
        TogglePauseState(false);
        panelUI.SetActive(true);
        HUD.enabled = true;
    }
    // Funções para a tela de game over
    public void GameOver(){
        gameOver.gameObject.SetActive(true);
        TogglePauseState(true);
        panelUI.SetActive(false );
        HUD.enabled = false;
        quests.SetActive(false);
    }
    public void TimeOn(){
        TogglePauseState(false);
    }

    // Alternador de estado de tempo do jogo
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
