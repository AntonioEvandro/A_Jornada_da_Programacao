using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    [Header("Player")]
    [Tooltip(
        "Objeto para obter a função de salvar diálogo e bloquer o movimento do player"
    )]
    [SerializeField]
    private GameObject player;

    [Header("Dialog ID")]
    [Tooltip("Id do diálogo, recebido pelo botão")]
    public int id;

    [Space(15)]

    [SerializeField]
    [Header("Dialog box")]
    [Tooltip("Caixa de diálogo para aparecer os elementos da conversa")]
    private GameObject dialogueBox;
    private Writing writing;

    [Header("Animation")]
    [Tooltip("Animações de entrada e saida da caixa de diálogo")]
    [SerializeField]
    private Animator animator;

    [Header("Character name")]
    [Tooltip("Texto para por o nome do personagem que está falando")]
    [SerializeField]
    private TextMeshProUGUI nameCharacter;

    private Dialog currentDialog;
    private int lineIndex;
    private Queue<string> Lines;
    private bool btnNext = true;
   
    // Start is called before the first frame update
    void Start()
    {
        writing = GetComponent<Writing>();
    }
    // Update is called once per frame
    void Update()
    {
        KeyNext();/*
        if(dialogueBox.activeSelf){
            if(!player.GetComponent<Items>().LoadMission(id).missionActive){
                
            }else{
                Debug.Log("Diálogo já foi exibido!");
            }
        }*/
    }

    public void StartDialog(Dialog dialog){
        player.GetComponent<ControlePersonagem>().BlockMovent();
        //Deixa a caixa de diálogo visível
        dialogueBox.SetActive(true);
        // Inicializa a fila de falas
        Lines = new Queue<string>();
        currentDialog = dialog;
        lineIndex = 0;

        NextLine();
    }

    public void NextLine(){
        if(writing.ItsShow){
            writing.ShowFullText();
            return;
        }
        if (Lines.Count == 0){
            if(lineIndex < currentDialog.dialogues.Length){
                //Coloca o nome do personagem na caixa de diálogo
                nameCharacter.text = currentDialog.dialogues[lineIndex].name;

                //Coloca todas as falas numa fila
                foreach (string line in currentDialog.dialogues[lineIndex].lines){
                    Lines.Enqueue(line);
                }
                lineIndex++;
            }else{
                //bloqueia o botão de pular diálogo
                btnNext = false;
                // Torna a caixa de diálogo invisível
                player.GetComponent<Items>().SaveDialogue(id);
                // Chama a função de fechar a caixa de diálogo
                StartCoroutine(CloseBox());
                return;
            }
        }
        writing.ShowTextWriting(Lines.Dequeue());
    }
    // Fechar caixa de diálogo
    private IEnumerator CloseBox(){
        animator.Play("DialogBoxExit");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        dialogueBox.SetActive(false);
        player.GetComponent<ControlePersonagem>().UnBlockMovent();
    }

    // Botão de pular linhas de diálogos
    public void BtnNext(){
        if(btnNext){
            NextLine();
        }
    }
    // Tecla de pular linhas de diálogos
    public void KeyNext(){
        if(Input.GetKeyDown(KeyCode.Return) && btnNext){
            NextLine();
        }
    }
}
