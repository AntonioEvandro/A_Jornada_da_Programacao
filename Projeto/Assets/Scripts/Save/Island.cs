using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    [SerializeField]
    private GameObject player, partner, joao, bode, onca, alface, canoa;
    private bool resposta01, proxDialogo, island;
    private readonly int idDialog = 8;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadItems());
    }

    // Jogo frescoda mulesta, tem q esperar pra ele carregar os dados >:(
    private IEnumerator LoadItems(){
        yield return new WaitForSeconds(0.05f);
        Loader();
    }
    public void Quest(){
        Loader();
    }

    private void Loader(){
        //Atribuindo valores
        resposta01 = player.GetComponent<Items>().LoadDialogue(idDialog);
        if(resposta01){
            island = player.GetComponent<Items>().LoadIsland();
            proxDialogo = player.GetComponent<Items>().LoadDialogue(idDialog+1);
            //Debug.Log("Resposta exibida: " + resposta01 + " Ilha habilitada: " + island);

            //posicionamento dos elementos da quest01
            if (!island){
                if(!proxDialogo){
                    player.transform.position = new Vector2(12, 0);
                    partner.transform.position = new Vector2(11.3f, 0);
                }
                joao.transform.localPosition = new Vector2(15.33f,4);
                bode.transform.localPosition = new Vector2(14.5f,3.5f);
                onca.transform.localPosition = new Vector2(16,3.3f);
                alface.transform.localPosition = new Vector2(15.3f,3.3f);
                canoa.transform.localPosition = new Vector2(17.2f,3.5f);
            }else{
                if(!proxDialogo){
                    player.transform.localPosition = new Vector2(22.5f, 2.5f);
                    partner.transform.localPosition = new Vector2(20.5f, 2.5f);
                    //PlayerTP();
                }
                joao.transform.localPosition = new Vector2(23,3);
                bode.transform.localPosition = new Vector2(23,3);
                onca.transform.localPosition = new Vector2(23,3);
                alface.transform.localPosition = new Vector2(23,3);
                canoa.transform.localPosition = new Vector2(20,2);
            }
        }
    }
    private void PlayerTP(){//Posicionamento player
    }
}
