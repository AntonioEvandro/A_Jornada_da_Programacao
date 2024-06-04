using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island2 : MonoBehaviour
{
    [SerializeField]
    private GameObject player, joao, bode, onca, alface, canoa;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Ativar(){
        player.transform.position = new Vector2(22.5f, 2.5f);
        Quest1();
        player.GetComponent<Items>().SaveIsland2();
    }
    public void Quest1(){
        if (player.GetComponent<Items>().LoadIsland2()){
            joao.transform.position = new Vector2(23,3);
            bode.transform.position = new Vector2(23,3);
            onca.transform.position = new Vector2(23,3);
            alface.transform.position = new Vector2(23,3);
            canoa.transform.position = new Vector2(20,2);
        }
    }
}
