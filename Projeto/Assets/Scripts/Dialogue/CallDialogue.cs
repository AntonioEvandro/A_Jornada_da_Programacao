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

    /*/ Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){ // Verifica se diálogo pode ser exibido
            if (id == 0){
                if (items.LoadDialogue(id) != DialogState.Exibido){
                    Activate();        
                }
            }else if(id > 0){
                if(items.LoadDialogue(id-1) == DialogState.Exibido && items.LoadDialogue(id) != DialogState.Exibido){
                    Activate();        
                }
            }else{
                Debug.Log("Ops! Houve um erro.");
            }
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
                if(!items.LoadPartner()){
                    SendDialogue(true);
                }
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
