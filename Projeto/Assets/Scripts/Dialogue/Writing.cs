using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Writing : MonoBehaviour
{
/*    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
    [SerializeField]
    private TextMeshProUGUI text;
    
    [Header("Digitação")]
    [Tooltip(
        "Variável para velocidade de digitação.\nPor padrão é 0,02.\nMude nos testes, se quiser."
    )]
    [SerializeField]
    [Range(0.01f, 1.0f)]
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
