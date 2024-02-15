using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlePersonagem : MonoBehaviour
{
    public float velocidade = 5f; 
    private Rigidbody2D rb; 
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Adiciona um BoxCollider2D ao objeto do jogador
        BoxCollider2D boxCollider = gameObject.AddComponent<BoxCollider2D>();
        boxCollider.size = new Vector2();

        // Obtém a referência ao Animator
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float movimentoHorizontal = 0f;
        float movimentoVertical = 0f;

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            movimentoVertical = 0f;
            movimentoHorizontal = 0f;

            // Ativa a animação "Walking Up" no Animator
            animator.SetBool("Walking Up", false);
            animator.SetBool("Walking Down", false);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
        {
            movimentoHorizontal = 0f;
            movimentoVertical = 0f;

            // Desativa a animação "Walking Left" se a tecla não estiver pressionada
            animator.SetBool("Walking Right", false);
            animator.SetBool("Walking Left", false);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            movimentoVertical = 1f;

            // Ativa a animação "Walking Up" no Animator
            animator.SetBool("Walking Up", true);
            animator.SetBool("Walking Down", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movimentoVertical = -1f;

            // Ativa a animação "Walking Down" no Animator
            animator.SetBool("Walking Down", true);
            animator.SetBool("Walking Up", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movimentoHorizontal = -1f;

            // Ativa a animação "Walking Left" no Animator
            animator.SetBool("Walking Left", true);
            animator.SetBool("Walking Right", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movimentoHorizontal = 1f;

            // Desativa a animação "Walking Left" se a tecla não estiver pressionada
            animator.SetBool("Walking Right", true);
            animator.SetBool("Walking Left", false);
        }
        else 
        {
            // Desativa as animações verticais se as teclas não estiverem pressionadas
            animator.SetBool("Walking Up", false);
            animator.SetBool("Walking Down", false);
            animator.SetBool("Walking Left", false);
            animator.SetBool("Walking Right", false);

        }

        Vector2 movimento = new Vector2(movimentoHorizontal, movimentoVertical);

        rb.AddForce(movimento * velocidade);

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || 
        (Input.GetKey(KeyCode.W)! && Input.GetKey(KeyCode.S)!) || (Input.GetKey(KeyCode.A)! && Input.GetKey(KeyCode.D)!)){
            rb.velocity = Vector2.zero;
        }
        
        Debug.Log("<color=orange>Velocidade: </color>" + rb.velocity);
        Debug.Log("<color=blue>Movimento Horizontal: </color>" + movimentoHorizontal);
        Debug.Log("<color=green>Movimento Vertical: </color>" + movimentoVertical);
    }

    void FixedUpdate()
    {
        // Evitar atravessar objetos no cenário
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.tag == "Obstaculo") 
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
}
