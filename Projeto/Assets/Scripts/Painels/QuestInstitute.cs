using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInstitute : MonoBehaviour
{
    [Header("Player")]
    [Tooltip("Variável para pegar as funções dos scripts no player.\n")]
    [SerializeField]
    private GameObject player;
    
    [Header("Tela do desafio")]
    [Tooltip("Variável para pegar o canva da referente quest.")]
    [SerializeField]
    private GameObject quest;
    
    [Header("ID")]
    [Tooltip("ID da missão.")]
    public int id;
    void Start()
    {
        if (!player.GetComponent<Items>().LoadMission(id-1).missionActive || player.GetComponent<Items>().LoadMission(id).missionActive){
            CloseQuest();
        }
    }

    public void WrongOption()
    {
        player.GetComponent<HeartSystem>().DiminuirVida();
    }

    public void RigthOption()
    {
        CloseQuest();
        player.GetComponent<Items>().SaveMission(id);
        player.GetComponent<Items>().SaveCoins(10, true);
        Debug.Log("<color=blue>Resposta correta!!!</color>");
    }
    
    public void CloseQuest()
    {
        quest.GetComponent<ActivateChallenge>().DesactiveQuest();
    }
}
