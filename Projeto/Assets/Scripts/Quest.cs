using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WrongOption()
    {
        player.gameObject.GetComponent<HeartSystem>().DiminuirVida();
        player.GetComponent<SaveLoad>().SaveGame();
    }

    public void RigthOption()
    {
        player.gameObject.GetComponent<HeartSystem>().AumentarVida();
        player.gameObject.GetComponent<HeartSystem>().CloseQuest();
        player.GetComponent<SaveLoad>().SaveGame();
    }
}
