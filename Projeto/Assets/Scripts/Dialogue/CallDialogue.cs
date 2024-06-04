using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallDialogue : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private Dialog dialog;
    [SerializeField] private int id;
    [SerializeField] private GameObject dialogManager;

    [SerializeField] private State call;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            Activate();
        }
    }
    public void Activate(){
        switch (call)
        {
            case State.Partner://Ativar companheiro
                if(!player.GetComponent<Items>().LoadPartner()){
                    dialogManager.GetComponent<DialogSystem>().act = true;
                    dialogManager.GetComponent<DialogSystem>().StartDialog(dialog);
                }
            break;
            case State.Quest:
                dialogManager.GetComponent<DialogSystem>().act = true;
                dialogManager.GetComponent<DialogSystem>().id = id;
                dialogManager.GetComponent<DialogSystem>().StartDialog(dialog);
            break;
            case State.Dialog:
                dialogManager.GetComponent<DialogSystem>().id = id;
                dialogManager.GetComponent<DialogSystem>().StartDialog(dialog);
            break;
        }
    }
}
