using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public GameObject player;
    public Collider2D colisor;
    public int num;
    // Start is called before the first frame update
    void Start()
    {
        
        if(player.GetComponent<SaveLoad>().CarregarMissao(num)){
            CloseQuest();
        }else{
            colisor.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WrongOption()
    {
        player.gameObject.GetComponent<HeartSystem>().DiminuirVida();
    }

    public void RigthOption()
    {
        player.GetComponent<SaveLoad>().SalvarMissao(num);
        CloseQuest();
        Debug.Log("<color=blue>Resposta correta!!!</color> Sua recompensa <color=yellow>10</color> moedas");
        player.GetComponent<SaveLoad>().SalvarPontos(10);
    }
    
    public void CloseQuest()
    {
        transform.gameObject.SetActive(false);
        colisor.enabled = false;
    }
}
