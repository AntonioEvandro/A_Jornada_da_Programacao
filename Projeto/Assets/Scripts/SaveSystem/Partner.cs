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

    [SerializeField]
    private float minimalDistance;

    [Tooltip("RigidBody do companheiro")]
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Animator animator;

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
        if(playerPose.gameObject != null && player.GetComponent<Items>().LoadPartner()){
            //transform.position = Vector2.MoveTowards(transform.position, playerPose.position, speed * Time.deltaTime);
            Vector2 playerPos = this.playerPose.position;
            Vector2 currentPos = this.transform.position;

            float distance = Vector2.Distance(playerPos, currentPos);
            if (distance >= this.minimalDistance){
                Vector2 direction = playerPos - currentPos;
                direction = direction.normalized;
                //Debug.Log("Direção" + direction);
                this.rb.velocity = (this.speed * direction);
                //Debug.Log("velocidade" + this.rb.velocity);
                animator.SetFloat("Horizontal", direction.x);
                animator.SetFloat("Vertical", direction.y);
            }else{
                this.rb.velocity = Vector2.zero; // (0,0)
                animator.SetFloat("Horizontal", 0);
                animator.SetFloat("Vertical", -1);
            }
        }
    }

}
