using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partner : MonoBehaviour
{
    [Tooltip("Componente do Jogador")]
    [SerializeField]
    private GameObject player;
    private Transform playerPose;

    [Header("Speed Partner")]
    [Tooltip("Velocidade do companheiro")]
    [Range(0.01f, 10f)]
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        playerPose = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }
    private void FollowPlayer(){
        if(playerPose.gameObject != null){
            //transform.position = Vector2.MoveTowards(transform.position, playerPose.position, speed * Time.deltaTime);
            Vector2 playerPos = this.playerPose.position;
            Vector2 currentPos = this.transform.position;
            Vector2 direction = playerPos - currentPos;
            Debug.Log("Direção" + direction);
        }
    }
}
