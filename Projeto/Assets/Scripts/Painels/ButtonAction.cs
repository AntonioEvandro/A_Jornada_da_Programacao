using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
    public GameObject player;
    public GameObject botaoAcao;
    public GameObject painelUI;
    public int idDialogo;
    public int idQuest;
    
    // Função para mostrar o botão de ação enquanto estiver perto da quest
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Transform newParent;
        if (other.gameObject.CompareTag("Player"))
        {
            if (idDialogo == 0){
                if (!player.GetComponent<Items>().LoadDialogue(idDialogo)){
                    Send4Button();
                }
            }else if(idDialogo > 0){
                if(!player.GetComponent<Items>().LoadDialogue(idDialogo-1) || player.GetComponent<Items>().LoadDialogue(idDialogo)){
                    GetComponent<Collider2D>().enabled = false;
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
        player.GetComponent<Items>().SaveDialogue(idDialogo);
        GetComponent<ActivateChallenge>().ActiveQuest();
    }
    // Ativa o botão de ação e envia a função BtnClick para ele
    public void Send4Button(){
        Instantiate(botaoAcao).transform.parent = painelUI.transform;
        botaoAcao.SetActive(true);
        Button btn = botaoAcao.GetComponent<Button>();
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(BtnClick);
        if(Input.GetKey(KeyCode.F)){
            BtnClick();
        }
    }
}
