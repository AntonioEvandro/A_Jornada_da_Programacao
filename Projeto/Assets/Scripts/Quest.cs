using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public GameObject player;
    public Collider2D colisor;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        
        //if(player.GetComponent<SaveLoad>().CarregarMissao(id)){
        if (player.GetComponent<Items>().LoadMission(id).missionActive){
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
        player.GetComponent<Items>().SaveMission(id);
        CloseQuest();
        Debug.Log("<color=blue>Resposta correta!!!</color> Sua recompensa <color=yellow>10</color> moedas");
        player.GetComponent<Items>().SaveCoins(10, true);
    }
    
    public void CloseQuest()
    {
        transform.gameObject.SetActive(false);
        colisor.enabled = false;
    }
}
