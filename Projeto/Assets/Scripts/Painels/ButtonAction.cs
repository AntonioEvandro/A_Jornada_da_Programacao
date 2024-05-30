using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum State{
    Quest,Dialog,Market
}
public class ButtonAction : MonoBehaviour
{
    public GameObject player;
    public GameObject botaoAcao;
    public GameObject painelUI;
    public int id;

    [Header("Diálogo")]
    [Tooltip("Diálogo a ser enviado para exibição.\nCaso o botão seja para chamar o diálogo.")]
    [SerializeField]
    private Dialog dialog;

    [SerializeField]
    [Tooltip(
        "Pega o script DialogManager dentro do objeto GameManager\npara usar a função de mostrar o diálogo"
    )]
    private GameObject dialogManager;

    [Header("Chamada")]
    [Tooltip(
        "Variável usada para chamar uma função de acordo com o estado.\nSe for Quest chamará o desafio,\n caso for Dialog será chamado o diálogo\n ou se for Market mostrará o mercado."
    )]
    [SerializeField]
    private State call;//chama determinada função
    private GameObject bt;
    
    // Função para mostrar o botão de ação enquanto estiver perto da quest
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (call){
                case State.Quest://chama o desafio
                    if (id == 0){
                        if (!player.GetComponent<Items>().LoadMission(id).missionActive){
                            Send4Button();
                        }
                    }else if(id > 0){
                        if(player.GetComponent<Items>().LoadMission(id-1).missionActive && !player.GetComponent<Items>().LoadMission(id).missionActive){
                            Send4Button();
                        }
                    }else{
                        Debug.Log("Ops! Houve um erro.");
                    }
                    break;
                case State.Dialog://chama o dialogo
                    if (id == 0){
                        if (!player.GetComponent<Items>().LoadDialogue(id)){
                            Send4Button();
                        }
                    }else if(id > 0){
                        if(player.GetComponent<Items>().LoadDialogue(id-1) && !player.GetComponent<Items>().LoadDialogue(id)){
                            Send4Button();
                        }
                    }else{
                        Debug.Log("Ops! Houve um erro.");
                    }
                    break;
                case State.Market://Chama o mercado
                    break;
            }
        }
    }
    // Função para ocultar o botão de ação enquanto estiver perto da quest
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            Destroy(bt);
        }
    }
    // Função para ocultar o botão de ação depois que for clicado
    public void BtnClick(){
        bt.SetActive(false);
        switch (call){
            case State.Quest:
                GetComponent<ActivateChallenge>().ActiveQuest();
                break;
            case State.Dialog:
                dialogManager.GetComponent<DialogSystem>().StartDialog(dialog);
                player.GetComponent<Items>().SaveDialogue(id);
                break;
            case State.Market:
                break;
        }
    }
    // Ativa o botão de ação e envia a função BtnClick para ele
    public void Send4Button(){
        bt = Instantiate(botaoAcao);
        bt.transform.SetParent(painelUI.transform,false);
        bt.SetActive(true);
        bt.GetComponent<Button>().onClick.RemoveAllListeners();
        bt.GetComponent<Button>().onClick.AddListener(BtnClick);
        if(Input.GetKey(KeyCode.F)){
            BtnClick();
        }
    }
}
