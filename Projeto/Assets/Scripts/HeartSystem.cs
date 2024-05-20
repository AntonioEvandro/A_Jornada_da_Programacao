using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HeartSystem : MonoBehaviour
{
    public int vidaMaxima;
    public int vidaAtual;
    public Transform gameOver;

    public TMP_Text heartText;
    public GameObject Quests;

    // Start is called before the first frame update
    void Start()
    {
        //vidaAtual = GetComponent<Items>().LoadLifes();
    }

    public void DiminuirVida()
    {
        //vidaAtual -= 1;
        GetComponent<Items>().SaveLifes(1, false);

        Debug.Log("<color=red>Resposta errada!</color>");

        if(GetComponent<Items>().LoadLifes() > 3){
            vidaMaxima -= 1;
        }

        if(GetComponent<Items>().LoadLifes() <= 0)
        {
            Debug.Log("<color=black>Fim de jogo!</color>");
            gameOver.gameObject.SetActive(true);
            Quests.SetActive(false);
        }
    }
    public void AumentarVida()
    {
        //vidaAtual += 1;
        if (GetComponent<Items>().LoadCoins()>= 10){
            GetComponent<Items>().SaveLifes(1, true);
            if(GetComponent<Items>().LoadLifes() == vidaMaxima + 1)
            {
                vidaMaxima += 1;
            }
            Debug.Log("<color=Green>Vida adquirida com sucesso!</color> Total: <color=red>" + GetComponent<Items>().LoadLifes() + "</color>. Saldo: <color=yellow>" + GetComponent<Items>().LoadCoins() + "</color>");
        }else{
            Debug.Log("<color=red> Moedas insuficientes! </color> Seu saldo é: <color=Orange>" + GetComponent<Items>().LoadCoins() + "</color>");
        }
    }
    
}
