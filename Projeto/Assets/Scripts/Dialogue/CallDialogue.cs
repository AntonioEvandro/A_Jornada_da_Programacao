using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallDialogue : MonoBehaviour
{
    [SerializeField] private Items items;//Encurta chamada do GameObjeto: player.GetComponent<Items>() apenas por: Items

    [SerializeField] private Dialog dialog;
    [SerializeField] private int id;
    [SerializeField] private DialogSystem dialogManager; //Encurtado GetComponent<DialogSystem>(). -> dialogManager

    [SerializeField] private State call;

    [Tooltip("Caso o dialogo deve aparecer apos outro no mesmo colisor")]
    [SerializeField] private bool SecDialog;
    
    [Tooltip("Ligado é resposta a um desafio, desligado apenas um diálogo normal.\n Será exibido se o desafio anterior estiver concluido.")]
    [SerializeField] private bool isResponse = false;
    [SerializeField] private int missionId; // ID do desafio anterior
    private bool stopVerify = false; // Fazer o Update() parar de chamar o Verify()

    /*/ Start is called before the first frame update
    void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        if(!stopVerify){
            if(isResponse){
                if( items.LoadMission(missionId).missionActive){
                    Verify();
                }
            }else if(SecDialog && items.LoadMercado()){
                Verify();
            }
        }
    }
    private void Verify(){
        if(items.LoadDialogue(id) == DialogState.Exibido){
            stopVerify = true;
        }else if(items.LoadDialogue(id) == DialogState.Exibindo){
            Activate();
        }else if  (items.LoadDialogue(id) == DialogState.Exibir){
            if(id == 0){
                Activate();        
            }else if(id > 0 && items.LoadDialogue(id-1) == DialogState.Exibido){
                Activate();
            }/*else{
                Debug.LogFormat("ID invalido {0}!", id);
            }*/
        }else{
            Debug.Log("Ops! Provávelmente o diálogo já foi exibido ou houve algum outro erro.");
        }
    }
    private void OnTriggerStay2D(Collider2D other){
        if(!isResponse && other.gameObject.CompareTag("Player") && !stopVerify){
            Verify();
        }
    }

    private void SendDialogue(bool act){
        if(act){
            dialogManager.act = true;
            dialogManager.tipo = call;
        }
        dialogManager.id = id;
        dialogManager.StartDialog(dialog);
    }
    public void Activate(){
        stopVerify = true;
        switch (call)// Verifica se após o diálogo irá acontecer algo
        {
            case State.Quest:// Ativar  desafio
                SendDialogue(true);
            break;
            case State.Dialog:// Chamar outro diálogo após exibir esse
                SendDialogue(true);
            break;
            case State.Market:// Ativa o mercado
                SendDialogue(true);
            break;
            case State.Partner:// Chamar ativar/desativar companheiro
                SendDialogue(true);
            break;
            case State.Island: // Ativar segunda ilha
                SendDialogue(true);
            break;
            default: // Apenas chama o diálogo;
                SendDialogue(false);
            break;
        }
    }
}
