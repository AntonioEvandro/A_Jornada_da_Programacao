using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlePersonagem : MonoBehaviour
{
    public float velocidade = 5f; 
    public Rigidbody2D rb; 
    public Animator animator;

    Vector2 movimento;

    void Start()
    {
        
    }

    void Update()
    {
        movimento.x = Input.GetAxisRaw("Horizontal");
        movimento.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("horizontal", movimento.x);
        animator.SetFloat("vertical", movimento.y);
        animator.SetFloat("velocidade", movimento.sqrMagnitude);

        if (movimento != Vector2.zero){
            animator.SetFloat("horizontalIdle", movimento.x);
            animator.SetFloat("verticalIdle", movimento.y);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movimento * velocidade * Time.fixedDeltaTime);
    }
}
