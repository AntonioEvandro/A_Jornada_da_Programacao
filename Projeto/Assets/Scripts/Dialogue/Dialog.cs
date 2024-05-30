using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "ScriptableObject/Dialog")]
public class Dialog : ScriptableObject{
    public WordsOfDialogue[] dialogues;
}

[System.Serializable]
public class WordsOfDialogue{

    [Header("Nome")]
    [Tooltip("Nome do personagem que está falando")]
    public string name;

    [Header("Diálogo")]
    [Tooltip("Diálogo com as falas do personagem")]
    [TextArea(5,10)]
    public string[] lines;
}