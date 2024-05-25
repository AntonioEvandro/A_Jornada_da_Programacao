using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPanels : MonoBehaviour
{
    public Canvas HUD;
    public GameObject pauseMenu;
    public GameObject panelUI;
    public GameObject dialogueBox;
    public GameObject quests;
    public GameObject market;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        HUD.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
