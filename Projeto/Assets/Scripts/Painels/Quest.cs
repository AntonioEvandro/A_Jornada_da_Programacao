using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public GameObject player;
    public GameObject quest;
    public int id;

    [Space(20)]

    [SerializeField] private Dialog response;
    [SerializeField] private int idDialog;
    [SerializeField] private GameObject dialogManager;
    [SerializeField] private State res;

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
        player.GetComponent<Items>().SaveCoins(10, true);
        Debug.Log("<color=blue>Resposta correta!!!</color>");
        CallResponse();
    }
    
    public void CloseQuest()
    {
        quest.GetComponent<ActivateChallenge>().DesactiveQuest();
        player.GetComponent<ControlePersonagem>().UnBlockMovent();
    }
    public void CallResponse(){
        switch (res)
        {
            case State.Dialog:// Chama o diálogo do NPC após a resposta correta
                dialogManager.GetComponent<DialogSystem>().id = idDialog;
                dialogManager.GetComponent<DialogSystem>().StartDialog(response);
            break;
            default:
                Debug.Log("Sem diálogos pós resposta.");
            break;
        }
    }
}
