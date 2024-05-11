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
        vidaAtual = gameObject.GetComponent<SaveLoad>().CarregarVidas();
        //UpdateCount();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCount();
    }

    public void DiminuirVida()
    {
        vidaAtual -= 1;
        gameObject.GetComponent<SaveLoad>().SalvarVidas(vidaAtual);
        //UpdateCount();

        Debug.Log("<color=red>Resposta errada!</color>");

        if(vidaMaxima > 3){
            vidaMaxima -= 1;
        }

        if(vidaAtual <= 0)
        {
            Debug.Log("<color=black>Fim de jogo!</color>");
            gameOver.gameObject.SetActive(true);
            Quests.SetActive(false);
        }
    }
    public void AumentarVida()
    {
        vidaAtual += 1;
        gameObject.GetComponent<SaveLoad>().SalvarVidas(vidaAtual);
        //UpdateCount();
        if(vidaAtual == vidaMaxima + 1)
        {
            vidaMaxima += 1;
        }
    }


    // Atualizando vida no contador
    private void UpdateCount()
    {
        heartText.text = gameObject.GetComponent<SaveLoad>().CarregarVidas().ToString();
    }
    
}
