using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
    public GameObject player;
    private CircleCollider2D colisor;
    public GameObject botaoAcao;
    public int idDialogo;
    public int idQuest;
    // Start is called before the first frame update
    void Start()
    {
        colisor = GetComponent<CircleCollider2D>();
    }
    // Função para mostrar o botão de ação enquanto estiver perto da quest
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (player.GetComponent<Items>().LoadDialogue(idDialogo)){
                botaoAcao.SetActive(false);
            }else{
                botaoAcao.SetActive(true);
                // Envia uma função para o botão de ação
                Button btn = botaoAcao.GetComponent<Button>();
                btn.onClick.RemoveListener(ButtonClick);
                btn.onClick.AddListener(ButtonClick);
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
    public void ButtonClick(){
        botaoAcao.SetActive(false);
        player.GetComponent<Items>().SaveDialogue(idQuest);
        GetComponent<ActivateChallenge>().ActiveQuest();
    }
}
