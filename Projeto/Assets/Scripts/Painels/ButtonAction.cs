using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
    public GameObject player;
    public GameObject botaoAcao;
    public int idDialogo;
    public int idQuest;
    
    // Função para mostrar o botão de ação enquanto estiver perto da quest
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.F))
        {
            if (idDialogo == 0){
                if (player.GetComponent<Items>().LoadDialogue(idDialogo)){
                    botaoAcao.SetActive(false);
                }else{
                    Send4Button();
                }
            }else if(idDialogo > 0){
                if(!player.GetComponent<Items>().LoadDialogue(idDialogo-1) || player.GetComponent<Items>().LoadDialogue(idDialogo)){
                    botaoAcao.SetActive(false);
                }else{
                    Send4Button();}
            }else{
                Debug.Log("Ops! Houve um erro.");
            }
        }
    }
    // Função para ocultar o botão de ação enquanto estiver perto da quest
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            botaoAcao.SetActive(false);
        }
    }
    // Função para ocultar o botão de ação depois que for clicado
    public void BtnClick(){
        botaoAcao.SetActive(false);
        player.GetComponent<Items>().SaveDialogue(idQuest);
        GetComponent<ActivateChallenge>().ActiveQuest();
    }
    // Ativa o botão de ação e envia a função BtnClick para ele
    public void Send4Button(){
        botaoAcao.SetActive(true);
        Button btn = botaoAcao.GetComponent<Button>();
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(BtnClick);
    }
}
