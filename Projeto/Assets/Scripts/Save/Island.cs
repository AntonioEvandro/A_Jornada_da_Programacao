using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    [SerializeField]
    private GameObject player, partner, joao, bode, onca, alface, canoa;
    private bool dialogo, island, dialogLoaded;
    // Start is called before the first frame update
    void Start()
    {
        dialogLoaded = false;
        StartCoroutine(LoadItems());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoPt1(){
        player.transform.position = new Vector2(12, 0);
        partner.transform.position = new Vector2(11.3f, 0);
        
        joao.transform.localPosition = new Vector2(15.33f,4);
        bode.transform.localPosition = new Vector2(14.5f,3.5f);
        onca.transform.localPosition = new Vector2(16,3.3f);
        alface.transform.localPosition = new Vector2(15.3f,3.3f);
        canoa.transform.localPosition = new Vector2(17.2f,3.5f);
        //player.GetComponent<Items>().SaveIsland();
    }
    public void GoPt2(){
        player.transform.localPosition = new Vector2(22.5f, 2.5f);
        partner.transform.localPosition = new Vector2(20.5f, 2.5f);
        
        joao.transform.localPosition = new Vector2(23,3);
        bode.transform.localPosition = new Vector2(23,3);
        onca.transform.localPosition = new Vector2(23,3);
        alface.transform.localPosition = new Vector2(23,3);
        canoa.transform.localPosition = new Vector2(20,2);

    }
    public void LoadIsland(){
        if(!dialogLoaded){
            dialogo = player.GetComponent<Items>().LoadDialogue(8);
            island = player.GetComponent<Items>().LoadIsland();
        }else{
            dialogLoaded = false;
        }
        Debug.Log("Dialogo visto: " + dialogo + " Ilha habilitada: " + island);
        if (!island && dialogo){
            GoPt1();
        }else if(island && dialogo){
            GoPt2();
        }
    }

    // Jogo frescoda mulesta, tem q esperar pra ele carregar os dados >:(
    private IEnumerator LoadItems(){
        yield return new WaitForSeconds(0.05f);
        dialogo = player.GetComponent<Items>().LoadDialogue(8);
        island = player.GetComponent<Items>().LoadIsland();
        dialogLoaded = true;
        LoadIsland();
    }
}
