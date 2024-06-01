using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Writing : MonoBehaviour
{
    [Space(15)]
    [SerializeField]
    private TextMeshProUGUI text;
    
    [Header("Digitação")]
    [Tooltip(
        "Variável para ajustar velocidade de digitação.\nQuanto menor o valor mais rápido será a exibição.\nPor padrão é 0.2, mas pode mudar nos testes."
    )]
    [SerializeField]
    [Range(0.001f, 0.5f)]
    private float typingSpeed = 0.2f;
    public bool ItsShow { get; private set; }
    private IEnumerator effectCoroutine;

    public void ShowTextWriting(string dialogueText){
        text.text = dialogueText;

        effectCoroutine = WriteEffect();
        StartCoroutine(effectCoroutine);
        ItsShow = true;
    }
    public void ShowFullText(){
        StopCoroutine(effectCoroutine);
        text.maxVisibleCharacters = text.text.Length;

        ItsShow = false;
    }

    private IEnumerator WriteEffect()
    {
        int totalCharacters = text.text.Length;
        text.maxVisibleCharacters = 0;
        for(int i = 0; i <= totalCharacters; i++){
            text.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typingSpeed);
        }
        ItsShow = false;
    }

}
