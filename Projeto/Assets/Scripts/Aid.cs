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
        missao = player.GetComponent<Items>().LoadMission(id);
        //LogMissionLoaded(missao);
        DesactiveButtons();
    }

    // Update is called once per frame
    void Update()
    {}
    public void Tip(){
        tip.SetActive(true);
        player.GetComponent<Items>().SaveMissionAidsItem(id, 0);
        DesactiveButtons();
        btnTip.interactable = false;
    }
    public void Advice(){
        advice.SetActive(true);
        player.GetComponent<Items>().SaveMissionAidsItem(id, 1);
        DesactiveButtons();
    }
    public void M2(){
        opc1.interactable = false;
        opc2.interactable = false;
        player.GetComponent<Items>().SaveMissionAidsItem(id, 2);
        DesactiveButtons();
    }
    public void DesactiveButtons(){
        if(!(missao.aidsUsed >= 0 && missao.aidsUsed < 2)){
            btnTip.interactable = false;
            btnAdvice.interactable = false;
            btnM2.interactable = false;
        }
        if (!missao.tipsUsed){
            btnTip.interactable = true;
        }else if(missao.tipsUsed){
            btnTip.interactable = false;
        }else if(!missao.adviceUsed){
            btnAdvice.interactable = true;
        }else if(missao.adviceUsed){
            btnAdvice.interactable = false ;
        }else if(!missao.m2Used){
            btnM2.interactable = true;
        }else if(missao.m2Used){
            btnM2.interactable= false;
        }else{
            Debug.LogError("Ops! houve algum erro. Verifique os seguintes valores: ");
            LogMissionLoaded(missao);
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
