using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aid : MonoBehaviour
{
    public int uses;
    public Button btnTip;
    public Button btnAdvice;
    public Button btnM2;
    public GameObject tip;
    public GameObject advice;
    public Button opc1;
    public Button opc2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {}
    public void Tip(){
        tip.SetActive(true);
        uses += 1;
        DesactiveButtons();
        btnTip.interactable = false;
    }
    public void Advice(){
        advice.SetActive(true);
        uses += 1;
        DesactiveButtons();
        btnAdvice.interactable = false;
    }
    public void M2(){
        opc1.interactable = false;
        opc2.interactable = false;
        uses += 1;
        DesactiveButtons();
        btnM2.interactable = false;
    }
    public void DesactiveButtons(){
        if(!(uses >= 0 && uses < 2)){
            btnTip.interactable = false;
            btnAdvice.interactable = false;
            btnM2.interactable = false;
        }
    }
}
