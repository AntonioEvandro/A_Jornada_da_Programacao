using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePersonagem : MonoBehaviour
{
    public float velocidade = 5f; 
    private Rigidbody2D rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        BoxCollider2D boxCollider = gameObject.AddComponent<BoxCollider2D>();

        boxCollider.size = new Vector2(1f, 1f);
    }

    void Update()
    {
        float movimentoHorizontal = 0f;
        float movimentoVertical = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            movimentoVertical = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movimentoVertical = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movimentoHorizontal = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movimentoHorizontal = 1f;
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
