using Unity.VisualScripting;
using UnityEngine;

public class ControlePersonagem : MonoBehaviour
{
    public enum AniPlayer{
        idle, walk, main
    }
    [Header("Movimentação")]
    [Tooltip(
        "Variáveis para movimentação.\nPor padrão é 3.75.\nMude nos testes, se quiser."
    )]
    [SerializeField]
    [Range(2.0f, 15.0f)]
    private float velocidade = 5f;
    [SerializeField]
    private Rigidbody2D rb;
    private bool blockMove = false;
    [Space(15)]
    [Tooltip("Controle de animações do player")]
    [SerializeField]
    private Animator animator;

    [Header("NPC")]
    [Tooltip("Posição do npc")]
    [SerializeField]
    private Transform npc;

    [Space(13)]
    [Tooltip("Sistema de diálogo")]

    Vector2 movimento;

    void Update()
    {
        // Verifica se o jogo não está pausado
        if (Time.timeScale > 0 && !blockMove)
        {
            movimento.x = Input.GetAxisRaw("Horizontal");
            movimento.y = Input.GetAxisRaw("Vertical");

            Anim(AniPlayer.walk);

            if (movimento != Vector2.zero)
            {
                Anim(AniPlayer.idle);
            }

            rb.MovePosition(rb.position + Time.fixedDeltaTime * velocidade * movimento.normalized);
        }
        else
        {
            // Congela o personagem quando o jogo está pausado ou a caixa de diálogo está ativa
            movimento = Vector2.zero;
            rb.velocity = Vector2.zero;
            Anim(AniPlayer.walk);
        }
    }
    public void BlockMovent(){
        blockMove = true;
    }
    public void UnBlockMovent(){
        blockMove = false;
    }
    public void Anim(AniPlayer ani){
        switch (ani)
        {
            case AniPlayer.idle:
                animator.SetFloat("horizontalIdle", movimento.x);
                animator.SetFloat("verticalIdle", movimento.y);
            break;
            case AniPlayer.walk:
                animator.SetFloat("horizontal", movimento.x);
                animator.SetFloat("vertical", movimento.y);
                animator.SetFloat("velocidade", movimento.sqrMagnitude);
            break;
            case AniPlayer.main:
                animator.SetFloat("horizontalIdle", 0.01f);
                animator.SetFloat("verticalIdle", 0);
            break;
            default:
            break;
        }
    }
}
