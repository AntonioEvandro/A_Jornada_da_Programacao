using UnityEngine;

public class ControlePersonagem : MonoBehaviour
{
    public float velocidade = 5f; 
    public Rigidbody2D rb; 
    public Animator animator;

    public Transform npc;

    public DialogueSystem dialogueSystem;

    Vector2 movimento;

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

        rb.MovePosition(rb.position + movimento * velocidade * Time.fixedDeltaTime);

        if (Mathf.Abs(transform.position.x - npc.position.x) < 2.0f) {
            if (Input.GetKeyDown(KeyCode.E)) {
                dialogueSystem.Next();
            }
        }
    }
}
