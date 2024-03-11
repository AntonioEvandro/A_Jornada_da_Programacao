using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public GameObject player;
    public Transform canvasQuest;
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
    }

    public void RigthOption()
    {
        player.gameObject.GetComponent<HeartSystem>().AumentarVida();
        canvasQuest.gameObject.SetActive(false);
    }
}
