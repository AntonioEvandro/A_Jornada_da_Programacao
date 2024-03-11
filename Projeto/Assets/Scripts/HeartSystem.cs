using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HeartSystem : MonoBehaviour
{
    public int vidaMaxima;
    public int vidaAtual;

    public TMP_Text heartText;

    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaMaxima;
        UpdateCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DiminuirVida()
    {
        vidaAtual -= 1;
        UpdateCount();

        Debug.Log("Resposta errada!");

        if(vidaMaxima > 3){
            vidaMaxima -= 1;
        }

        if(vidaAtual <= 0)
        {
            Debug.Log("Fim de jogo!");
        }
    }
    public void AumentarVida()
    {
        vidaAtual += 1;
        UpdateCount();
        if(vidaAtual == vidaMaxima + 1)
        {
            vidaMaxima += 1;
        }
        Debug.Log("Parabéns! Resposta correta, sua recompensa 1pv");
    }


    // Atualizando vida no contador
    private void UpdateCount()
    {
        heartText.text = vidaAtual.ToString();
    }
}
