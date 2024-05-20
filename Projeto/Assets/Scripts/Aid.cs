using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aid : MonoBehaviour
{
    public GameObject player;
    public Mission missao = new();
    public int id;
    public Button btnTip;
    public Button btnAdvice;
    public Button btnM2;
    public GameObject tip;
    public GameObject advice;
    public Button opc1;
    public Button opc2;
    // Start is called before the first frame update
    void Start()
    {
        LoadMission();
        LogMissionLoaded(missao);
    }
    
    public void LoadMission(){
        missao = player.GetComponent<Items>().LoadMission(id);
        //LogMissionLoaded(missao);
        DesactiveButtons();
    }
    public void Tip(){
        player.GetComponent<Items>().SaveMissionAidsItem(id, 0);
        LoadMission();
    }
    public void Advice(){
        player.GetComponent<Items>().SaveMissionAidsItem(id, 1);
        LoadMission();
    }
    public void M2(){
        player.GetComponent<Items>().SaveMissionAidsItem(id, 2);
        LoadMission();
    }
    public void DesactiveButtons(){
        if (!missao.tipsUsed){
            btnTip.interactable = true;
        }else if(missao.tipsUsed){
            btnTip.interactable = false;
            tip.SetActive(true);
        }
        if(!missao.adviceUsed){
            btnAdvice.interactable = true;
        }else if(missao.adviceUsed){
            btnAdvice.interactable = false ;
            advice.SetActive(true);
        }
        if(!missao.m2Used){
            btnM2.interactable = true;
        }else if(missao.m2Used){
            btnM2.interactable= false;
            opc1.interactable = false;
            opc2.interactable = false;
        }
        DesactiveAids();
    }
    public void DesactiveAids(){
        if(missao.aidsUsed < 0 || missao.aidsUsed >= 2){
            btnTip.interactable = false;
            btnAdvice.interactable = false;
            btnM2.interactable = false;
            Debug.Log("Número máximo de ajudas atingidos!");
        }
    }
    public void LogMissionLoaded(Mission m) {        
        Debug.Log("<color=with>Missão carregada</color>");
        Debug.Log("<color=Orange> Id: </color><color=Green>" + m.id + "</color>");
        Debug.Log("<color=Orange> Ativada: </color><color=Red>" + m.missionActive + "</color>");
        Debug.Log("<color=Orange> Ajudas usadas: </color><color=Red>" + m.aidsUsed + "</color>");
        Debug.Log("<color=Orange> Recomendação: </color><color=Red>" + m.adviceUsed + "</color>");
        Debug.Log("<color=Orange> Dica: </color><color=Red>" + m.tipsUsed + "</color>");
        Debug.Log("<color=Orange> M2: </color><color=Red>" + m.m2Used + "</color>");
    }
}
