using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Items : MonoBehaviour
{
    public TMP_Text lifesTextHUD, coinsTextHUD, lifesTextUI, coinsTextUI, lifesTextGUI, coinsTextGUI, adviceTextHUD, tipsTextHUD, m2TextHUD,  adviceTextUI, tipsTextUI, m2TextUI, adviceTextGUI, tipsTextGUI, m2TextGUI;

    // Start is called before the first frame update
    void Start()
    {
        LoadPosition();
    }

    // Update is called once per frame
    void Update()
    {
        SavePosition();
        ItemsHUD();
        //ItemsUI();
        //ItemsGUI();
    }

    //Chamar as funcoes para salvar os dados
    public void SavePosition(){
        GetComponent<SaveLoad>().posicao = new float[2]{
            transform.position.x, transform.position.y
        };
        
    }
    public void SaveLifes(int l){
        GetComponent<SaveLoad>().vidas = l;
        GetComponent<SaveLoad>().SaveGame();
    }
    public void SaveCoins(int c){
        GetComponent<SaveLoad>().moedas += c;
    }
    public void SaveTips(int t){
        GetComponent<SaveLoad>().dicas = t;
    }
    public void SaveAdvices(int a){
        GetComponent<SaveLoad>().ajudas = a;
    }
    public void SaveMinus2(int m){
        GetComponent<SaveLoad>().m2 = m;
    }
    public void SavePartner(){
        GetComponent<SaveLoad>().companheiro = true;
    }
    public void SaveMissions(int mis){
        GetComponent<SaveLoad>().missoes[mis] = true;
    }


    // Chamar os itens
    public Vector3 LoadPosition(){
        return transform.position = new Vector3(
            GetComponent<SaveLoad>().posicao[0], GetComponent<SaveLoad>().posicao[1], 0
        );
        //Debug.Log("carregando posição" + GetComponent<SaveLoad>().posicao[0] + ", " + GetComponent<SaveLoad>().posicao[1]);
    }
    public int LoadLifes(){
        return GetComponent<SaveLoad>().vidas;
    }
    public int LoadCoins(){
        return GetComponent<SaveLoad>().moedas;
    }
    public int LoadTips(){
        return GetComponent<SaveLoad>().dicas;
    }
    public int LoadAdvices(){
        return GetComponent<SaveLoad>().ajudas;
    }
    public int LoadMinus2(){
        return GetComponent<SaveLoad>().m2;
    }
    public bool LoadPartner(){
        return gameObject.GetComponent<SaveLoad>().companheiro;
    }
    public bool LoadMission(int n){
        return gameObject.GetComponent<SaveLoad>().missoes[n];
    }


    //Chamar valores dos itens para serem mostrados em textos
    public void ItemsHUD(){
        lifesTextHUD.text = LoadLifes().ToString();
        coinsTextHUD.text = LoadCoins().ToString();
        //tipsTextHUD.text = LoadTips().ToString();
        //adviceTextHUD.text = LoadAdvices().ToString();
        //m2TextHUD.text = LoadMinus2().ToString();
    }
    public void ItemsUI(){
        lifesTextUI.text = LoadLifes().ToString();
        coinsTextUI.text = LoadCoins().ToString();
        tipsTextUI.text = LoadTips().ToString();
        adviceTextUI.text = LoadAdvices().ToString();
        m2TextUI.text = LoadMinus2().ToString();
    }
    public void ItemsGUI(){
        lifesTextGUI.text = LoadLifes().ToString();
        coinsTextGUI.text = LoadCoins().ToString();
        tipsTextGUI.text = LoadTips().ToString();
        adviceTextGUI.text = LoadAdvices().ToString();
        m2TextGUI.text = LoadMinus2().ToString();
    }
}
