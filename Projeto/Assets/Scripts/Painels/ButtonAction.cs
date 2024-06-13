using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
    public Items items; // Pega "Items items" ao invés de "GameObject player" Chamando "items." ao invés "player.GetComponent<Items>()."
    public GameObject botaoAcao;
    public GameObject painelUI;

    [Header("Mission")]
    [Tooltip("ID deste desafio.")]
    [SerializeField] private int idMission;

    [Tooltip("ID do diálogo anterior.\nLibera o desafio atual se o diálogo anterior já foi exibido.")]
    [SerializeField] private int idDialog;

    [Header("Diálogo")]
    [Tooltip("Diálogo a ser enviado para exibição.\nCaso o botão seja para chamar o diálogo.")]
    [SerializeField]
    private Dialog dialog;
    [SerializeField]
    [Tooltip(
        "Pega o script DialogManager dentro do objeto GameManager\npara usar a função de mostrar o diálogo"
    )]
    private DialogSystem dialogManager; // Removido o "GetComponent<DialogSystem>()." desnecessário nas chamadas
/*
    [Header("Mercado")]
    [Tooltip("Adicionar a tela de mercado para ser exibida.")]
    [SerializeField]
    private SwitchPanels market;*/


    [Header("Chamada")]
    [Tooltip(
        "Variável usada para chamar uma função de acordo com o estado.\nSe for Quest chamará o desafio,\n caso for Dialog será chamado o diálogo\n ou se for Market mostrará o mercado."
    )]
    [SerializeField]
    private State call;//chama determinada função
    private GameObject bt;
    private bool playerInRange = false; // Adicionado para rastrear se o jogador está no range
    private bool keyActionPressed = false; // Adicionado para rastrear se a tecla F foi pressionada
    private bool actionVerified = false; // Indica se a ação para o botão foi verificada
    
    // Função para verificar a ação que o botão fará
    private void VerifyAction(){
            switch (call){
                case State.Quest:// *** Para chamar o desafio ***
                    if(items.LoadDialogue(idDialog) == DialogState.Exibido){//verifica se exibiu o diálogo anterior
                        if (idMission == 0){ // Verifica se é a primeira missão do jogo
                            if (!items.LoadMission(idMission).missionActive){ // Verifica se foi respondida
                                Send4Button();
                            }
                        }else if(idMission > 0){ // Verifica se é uma missão adiante
                            if(items.LoadMission(idMission-1).missionActive && !items.LoadMission(idMission).missionActive){ // Verifica se o desafio anterior foi respondido e se essa pode ser respondida.
                                Send4Button();
                            }
                        }else{ // Caso não tenha satisfeito nenhuma das opções acima
                            Debug.Log("Ops! Houve um erro.");
                        }
                    }
                    break;
                case State.Dialog: // *** Para chamar o diálogo ***
                    if (idDialog == 0){ // Verifica se é o primeiro diálogo do jogo
                        if (items.LoadDialogue(idDialog) != DialogState.Exibido){ // Já foi exibido
                            Send4Button();
                        }
                    }else if(idDialog > 0){ // É um dos próximos diálogos
                        if(items.LoadDialogue(idDialog-1) == DialogState.Exibido && items.LoadDialogue(idDialog) != DialogState.Exibido){ // anterior foi exibido, esse pode ser exibido
                            Send4Button();
                        }
                    }else{ // Houve um problema
                        Debug.Log("Ops! Houve um erro.");
                    }
                    break;
                case State.Market://Chama o mercado
                    if (items.LoadDialogue(idDialog) == DialogState.Exibido){
                        Send4Button();
                    }
                    break;
            }
        }
    // Função para mostrar o botão de ação enquanto estiver perto da quest
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    // Função para ocultar o botão de ação enquanto estiver perto da quest
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            actionVerified = false;
            playerInRange = false;
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
                dialogManager.id = idDialog;
                dialogManager.StartDialog(dialog);
                break;
            case State.Market:
                dialogManager.act = true;
                dialogManager.tipo = call;
                dialogManager.StartDialog(dialog);
                break;
        }
        keyActionPressed = false; // Define a tecla F como não pressionada após chamar BtnClick()
    }
    // Ativa o botão de ação e envia a função BtnClick para ele
    public void Send4Button(){
        bt = Instantiate(botaoAcao);
        bt.transform.SetParent(painelUI.transform,false);
        bt.SetActive(true);
        bt.GetComponent<Button>().onClick.RemoveAllListeners();
        bt.GetComponent<Button>().onClick.AddListener(BtnClick);
        /*if(Input.GetKey(KeyCode.F)){
            BtnClick();
        }*/
        actionVerified = true;
    }

    /*private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && bt != null && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Clicado!");
            BtnClick();
        }
    }*/
    void Update(){
        if(playerInRange){
            if(items.LoadDialogue(idDialog) == DialogState.Exibido && !actionVerified){
                VerifyAction();
            }
            if (bt != null && bt.activeSelf && Input.GetKeyDown(KeyCode.E) && !keyActionPressed)
            {
                BtnClick();
                keyActionPressed = true; // Define a tecla Espaço como pressionada após chamar BtnClick()
            }
        }
    }
}
