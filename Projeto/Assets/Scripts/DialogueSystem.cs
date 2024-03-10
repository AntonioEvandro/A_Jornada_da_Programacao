using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATE {
    DISABLED,
    WAITING,
    TYPING
}

public class DialogueSystem : MonoBehaviour {

    public DialogueData playerDialogueData;
    public DialogueData joaoDialogueData;

    int currentText = 0;
    bool finished = false;

    TypeTextAnimation typeText;
    DialogueUI dialogueUI;

    STATE state;

    public Transform npcJoao; // Referência ao NPC "Joao"

    void Awake() {
        typeText = FindObjectOfType<TypeTextAnimation>();
        dialogueUI = FindObjectOfType<DialogueUI>();

        typeText.TypeFinished = OnTypeFinished;
    }

    void Start() {
        StartPlayerDialogue(); // Inicia o diálogo do jogador assim que o jogo começar
    }

    void Update() {
        if (state == STATE.DISABLED) return;

        switch (state) {
            case STATE.WAITING:
                Waiting();
                break;
            case STATE.TYPING:
                Typing();
                break;
        }

        // Verifica se a tecla "E" foi pressionada para avançar no diálogo
        if (Input.GetKeyDown(KeyCode.E)) {
            Next();
        }
    }

    public void StartPlayerDialogue() {
        currentText = 0;
        dialogueUI.Enable(); // Ativa a caixa de diálogo
        LoadDialogue(playerDialogueData);
    }

    public void StartJoaoDialogue() {
        currentText = 0;
        dialogueUI.Enable(); // Ativa a caixa de diálogo
        LoadDialogue(joaoDialogueData);
    }

    public void StartJoaoDialogueAfterMonologue() {
        currentText = 0;
        dialogueUI.Enable(); // Ativa a caixa de diálogo
        LoadDialogue(joaoDialogueData);
    }

public void Next() {
    currentText++; // Incrementa o índice antes de carregar o próximo diálogo

    DialogueData currentData = GetCurrentDialogueData();

    if (currentText < currentData.talkScript.Count) {
        dialogueUI.SetName(currentData.talkScript[currentText].name);
        typeText.fullText = currentData.talkScript[currentText].text;

        typeText.StartTyping();
        state = STATE.TYPING;
    } else {
        Debug.LogWarning("End of dialogue reached."); // Aviso de que o fim do diálogo foi alcançado
        dialogueUI.Disable();
        state = STATE.DISABLED;
        currentText = 0;
        finished = false;
    }
}


    void OnTypeFinished() {
        state = STATE.WAITING;
    }

    void Waiting() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (!finished) {
                Next();
            } else {
                dialogueUI.Disable();
                state = STATE.DISABLED;
                currentText = 0;
                finished = false;
            }
        }
    }

    void Typing() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            typeText.Skip();
            state = STATE.WAITING;
        }
    }

    void LoadDialogue(DialogueData data) {
        dialogueUI.SetName(data.talkScript[currentText].name);
        typeText.fullText = data.talkScript[currentText].text;

        if (currentText == data.talkScript.Count) {
            finished = true;
        }

        typeText.StartTyping();
        state = STATE.TYPING;
    }

DialogueData GetCurrentDialogueData() {
    if (EstaPertoDoJoao(npcJoao)) {
        return joaoDialogueData;
    } else {
        return playerDialogueData;
    }
}

    public bool IsDialogueActive() {
        return state != STATE.DISABLED;
    }

    // Método para verificar se o jogador está perto do NPC "Joao"
    bool EstaPertoDoJoao(Transform npcJoao) {
        return Mathf.Abs(transform.position.x - npcJoao.position.x) < 2.0f;
    }
}
