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

    void Awake() {
        typeText = FindObjectOfType<TypeTextAnimation>();
        dialogueUI = FindObjectOfType<DialogueUI>();

        typeText.TypeFinished = OnTypeFinished;
    }

    void Start() {
        StartMonologue(); // Inicia o monólogo assim que o jogo começar
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

        // Verifica se a tecla "E" foi pressionada para avançar no monólogo
        if (Input.GetKeyDown(KeyCode.E) && GetCurrentDialogueData() == playerDialogueData) {
            Next();
        }
    }

    public void StartPlayerDialogue() {
        currentText = 0;
        LoadDialogue(playerDialogueData);
    }

    public void StartJoaoDialogue() {
        currentText = 0;
        LoadDialogue(joaoDialogueData);
    }

    public void StartMonologue() {
        currentText = 0;
        LoadDialogue(playerDialogueData); // Carrega o diálogo inicial (monólogo)
    }

    public void Next() {
        DialogueData currentData = GetCurrentDialogueData();

        if (currentText < currentData.talkScript.Count) {
            if (currentText == 0) {
                dialogueUI.Enable();
            }

            dialogueUI.SetName(currentData.talkScript[currentText].name);
            typeText.fullText = currentData.talkScript[currentText].text;

            typeText.StartTyping();
            state = STATE.TYPING;

            currentText++; // Incrementa o índice após acessar o elemento
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
        if (currentText == 0) {
            dialogueUI.Enable();
        }

        dialogueUI.SetName(data.talkScript[currentText].name);
        typeText.fullText = data.talkScript[currentText].text;

        if (currentText == data.talkScript.Count) {
            finished = true;
        }

        typeText.StartTyping();
        state = STATE.TYPING;
    }

    DialogueData GetCurrentDialogueData() {
        if (currentText == 0 || currentText > playerDialogueData.talkScript.Count) {
            return joaoDialogueData;
        } else {
            return playerDialogueData;
        }
    }
}
