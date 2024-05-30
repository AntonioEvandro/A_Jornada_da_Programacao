using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueBox;
    [SerializeField]
    private TextMeshProUGUI nameCharacter;
    [SerializeField]
    private TextMeshProUGUI textLine;

    private Dialog currentDialog;
    private int lineIndex;
    private Queue<string> Lines;
/*    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
*/
    public void StartDialog(Dialog dialog){
        //Deixa a caixa de diálogo visível
        dialogueBox.SetActive(true);
        // Inicializa a fila de falas
        Lines = new Queue<string>();
        currentDialog = dialog;
        lineIndex = 0;

        NextLine();
    }

    public void NextLine(){
        if (Lines.Count == 0){
            if(lineIndex < currentDialog.dialogues.Length){
                //Coloca o nome do personagem na caixa de diálogo
                nameCharacter.text = currentDialog.dialogues[lineIndex].name;

                //Coloca todas as falas numa fila
                foreach (string line in currentDialog.dialogues[lineIndex].lines){
                    Lines.Enqueue(line);
                }
                lineIndex++;
            }else{
                // Torna a caixa de dialogo invisível
                dialogueBox.SetActive(false);
                return;
            }
        }
        textLine.text = Lines.Dequeue();
    }
}
