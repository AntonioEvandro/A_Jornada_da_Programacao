using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInstitute : MonoBehaviour
{
    public GameObject player;
    public GameObject quest;
    public int id;
    // Start is called before the first frame update
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
