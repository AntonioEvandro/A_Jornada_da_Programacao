using System.Collections;
using System.Collections.Generic;
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
        boxCollider.size = new Vector2(1f, 1f);

        // Obtém a referência ao Animator
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float movimentoHorizontal = 0f;
        float movimentoVertical = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            movimentoVertical = 1f;

            // Ativa a animação "Walking Up" no Animator
            animator.SetBool("Walking Up", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movimentoVertical = -1f;

            // Ativa a animação "Walking Down" no Animator
            animator.SetBool("Walking Down", true);
        }
        else
        {
            // Desativa as animações verticais se as teclas não estiverem pressionadas
            animator.SetBool("Walking Up", false);
            animator.SetBool("Walking Down", false);
            animator.SetBool("Walking Left", false);

        }

        if (Input.GetKey(KeyCode.A))
        {
            movimentoHorizontal = -1f;

            // Ativa a animação "Walking Left" no Animator
            animator.SetBool("Walking Left", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movimentoHorizontal = 1f;

            // Desativa a animação "Walking Left" se a tecla não estiver pressionada
            animator.SetBool("Walking Left", false);
        }

        Vector2 movimento = new Vector2(movimentoHorizontal, movimentoVertical);

        rb.AddForce(movimento * velocidade);

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = Vector2.zero;
        }
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
