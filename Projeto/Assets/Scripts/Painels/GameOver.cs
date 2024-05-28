using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private string newGame;
    [SerializeField] private GameObject player;
    [SerializeField] 
    private GameObject gameManager;
    
    public void Jogar ()
    {
        gameManager.GetComponent<SwitchPanels>().TimeOn();
        player.GetComponent<SaveLoad>().TryAgain();
        SceneManager.LoadScene(newGame);
    }
}
