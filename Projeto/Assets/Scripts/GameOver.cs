using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private string newGame;
    
    public void Jogar ()
    {
        SceneManager.LoadScene(newGame);
    }
}
