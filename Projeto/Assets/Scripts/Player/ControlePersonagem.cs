using UnityEngine;

public class ControlePersonagem : MonoBehaviour
{
    [Header("Movimentação")]
    [Tooltip(
        "Variáveis para movimentação.\nPor padrão é 3.75.\nMude nos testes, se quiser."
    )]
    [SerializeField]
    [Range(2.0f, 15.0f)]
    private float velocidade = 5f;
    [Header("Movimentação")]
    [SerializeField]
    private Rigidbody2D rb;
    [Header("Animação")]
    [SerializeField]
    private Animator animator;

    [Header("NPC")]
    [Tooltip("Posição do npc")]
    [SerializeField]
    private Transform npc;

    [Header("Sistema de diálogo")]
    public DialogueSystem dialogueSystem;

    Vector2 movimento;

    void Update()
    {
        // Verifica se o jogo não está pausado
        if (Time.timeScale > 0 && !dialogueSystem.IsDialogueActive())
        {
            movimento.x = Input.GetAxisRaw("Horizontal");
            movimento.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("horizontal", movimento.x);
            animator.SetFloat("vertical", movimento.y);
            animator.SetFloat("velocidade", movimento.sqrMagnitude);

            if (movimento != Vector2.zero)
            {
                animator.SetFloat("horizontalIdle", movimento.x);
                animator.SetFloat("verticalIdle", movimento.y);
            }

            rb.MovePosition(rb.position + Time.fixedDeltaTime * velocidade * movimento.normalized);
        }
        else
        {
            // Congela o personagem quando o jogo está pausado ou a caixa de diálogo está ativa
            movimento = Vector2.zero;
            rb.velocity = Vector2.zero;
        }

        if (Mathf.Abs(transform.position.x - npc.position.x) < 2.0f && Time.timeScale > 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogueSystem.Next();
            }
        }
    }
}
