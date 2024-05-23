using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HeartSystem : MonoBehaviour
{
    public Transform gameOver;
    public GameObject Quests;

    public void DiminuirVida()
    {
        GetComponent<Items>().SaveLifes(false);

        Debug.Log("<color=red>Resposta errada!</color>");

        if(GetComponent<Items>().LoadLifes() <= 0)
        {
            Debug.Log("<color=black>Fim de jogo!</color>");
            gameOver.gameObject.SetActive(true);
            Quests.SetActive(false);
        }
    }
    public void AumentarVida()
    {
        GetComponent<Items>().SaveLifes(true);
    }
    
}
