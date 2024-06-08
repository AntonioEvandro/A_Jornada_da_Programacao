using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public GameObject player;
    public GameObject quest;
    public Island island;
    public int id;
    [Tooltip("Valor da recompensa")]
    public int coins;

    [Space(20)]

    [SerializeField] private Dialog response;
    [SerializeField] private int idDialog;
    [SerializeField] private GameObject dialogManager;
    [SerializeField] private State tipo;

    // Start is called before the first frame update
    void Start()
    {
        if (player.GetComponent<Items>().LoadMission(id).missionActive){
            CloseQuest();
        }else{
            quest.GetComponent<ActivateChallenge>().ActiveQuest();
            player.GetComponent<ControlePersonagem>().BlockMovent();
        }
    }

    public void WrongOption()
    {
        player.gameObject.GetComponent<HeartSystem>().DiminuirVida();
    }

    public void RigthOption()
    {
        CloseQuest();
        player.GetComponent<Items>().SaveMission(id);
        player.GetComponent<Items>().SaveCoins(coins, true);
        Debug.Log("<color=blue>Resposta correta!!!</color>");
        CallResponse();
    }
    
    public void CloseQuest()
    {
        quest.GetComponent<ActivateChallenge>().DesactiveQuest();
        player.GetComponent<ControlePersonagem>().UnBlockMovent();
    }

    private void SendDialogue(bool act){
        dialogManager.GetComponent<DialogSystem>().tipo = tipo;
        if(act){
            dialogManager.GetComponent<DialogSystem>().act = true;
        }
        dialogManager.GetComponent<DialogSystem>().id = idDialog;
        dialogManager.GetComponent<DialogSystem>().StartDialog(response);
    }
    public void CallResponse(){
        switch (tipo)
        {
            case State.Dialog:// Chama o diálogo do NPC após a resposta correta
                SendDialogue(false);
            break;
            case State.Island:
                SendDialogue(true);
            break;
            default:
                Debug.Log("Sem diálogos pós resposta.");
            break;
        }
    }
}
