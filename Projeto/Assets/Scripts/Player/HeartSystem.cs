using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HeartSystem : MonoBehaviour
{
    [Header("Fim de Jogo")]
    [Tooltip("Chama a função GameOver\n dentro do script SwitchPanels.cs \npara habilitar a tela de fim de jogo.")]
    [SerializeField]
    private GameObject gameOver;
    void Start()
    {
        StartCoroutine (VerificarVida());
    }
    public void DiminuirVida()
    {
        GetComponent<Items>().SaveLifes(false);

        Debug.Log("<color=red>Resposta errada!</color>");
        NoLife();
    }
    public void AumentarVida()
    {
        GetComponent<Items>().SaveLifes(true);
    }
    public void NoLife(){
        if(GetComponent<Items>().LoadLifes() <= 0)
        {
            Debug.Log("<color=black>Fim de jogo!</color>");
            gameOver.GetComponent<SwitchPanels>().GameOver();
        }
    }
    IEnumerator VerificarVida(){
        yield return new WaitForSeconds(0.05f);
        NoLife();
    }
}
