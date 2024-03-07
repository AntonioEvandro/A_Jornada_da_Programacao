using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeTextAnimation : MonoBehaviour
{
    public float typeDelay = 0.05f;
    public float displayDuration = 2f; // Tempo em segundos para manter o texto visível após a digitação
    public TextMeshProUGUI textObject;
    public GameObject dialogueBox; // Referência para o objeto da caixa de diálogo
    public string fullText; // Variável para armazenar o texto a ser exibido

    void Start()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        textObject.text = fullText;
        textObject.maxVisibleCharacters = 0;

        for (int i = 0; i <= fullText.Length; i++)
        {
            textObject.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typeDelay);
        }

        // Aguarda o tempo de exibição após a digitação
        yield return new WaitForSeconds(displayDuration);

        // Limpa o texto
        textObject.text = "";

        // Desativa a caixa de diálogo
        dialogueBox.SetActive(false);
    }
}
