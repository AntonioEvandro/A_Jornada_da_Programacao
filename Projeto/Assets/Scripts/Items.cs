using System;
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
        ItemsGUI();
        ItemsUI();
    }

    //          *** Funções para salvar os dados    ***
    public void SavePosition(){
        //Atualiza a váriavel posição com os dados de localização do player para salvar onde o player esteve anteriormente
        GetComponent<SaveLoad>().posicao = new(){
            transform.position.x, transform.position.y
        };
        
    }
    public void SaveCoins(int c, bool ss){
        if (ss){
            GetComponent<SaveLoad>().moedas += c;
            GetComponent<SaveLoad>().SaveGame();
            Debug.Log("Obteve <color=green>" + c + "</color> moedas. Saldo atual<color=yellow>" + LoadCoins() + "</color> moedas");
        }else if(!ss){
            GetComponent<SaveLoad>().moedas -= c;
            Debug.Log("<color=red>-" + c + "</color> moedas. Saldo atual<color=yellow>" + LoadCoins() + "</color> moedas");
        }else{
            Debug.LogError("Ops! houve algum erro. Veja se o seguinte valor é false ou true: " + ss);
        }
    }
    public void SaveLifes(int l, bool ss){
        if(ss){
            SaveCoins(10, false);
            GetComponent<SaveLoad>().vidas += l;
            GetComponent<SaveLoad>().SaveGame();
        }else if(!ss){
            GetComponent<SaveLoad>().vidas -= l;
            GetComponent<SaveLoad>().SaveGame();
        }else{
            Debug.LogError("Ops! houve algum erro. Veja se o seguinte valor é false ou true: " + ss);
        }
    }
    
    public void SaveTips(bool ss){
        if (ss){
            SaveCoins(10, false);
            GetComponent<SaveLoad>().dicas++;
            GetComponent<SaveLoad>().SaveGame();
        }else if(!ss){
            GetComponent<SaveLoad>().dicas--;
            GetComponent<SaveLoad>().SaveGame();
        }else{
            Debug.LogError("Ops! houve algum erro. Veja se o seguinte valor é false ou true: " + ss);
        }
    }
    public void SaveAdvices(bool ss){
        if (ss){
            SaveCoins(10, false);
            GetComponent<SaveLoad>().recomen++;
            GetComponent<SaveLoad>().SaveGame();
        }else if(!ss){
            GetComponent<SaveLoad>().recomen--;
            GetComponent<SaveLoad>().SaveGame();
        }else{
            Debug.LogError("Ops! houve algum erro. Veja se o seguinte valor é false ou true: " + ss);
        }
    }
    public void SaveMinus2(bool ss){
        if (ss){
            SaveCoins(10, false);
            GetComponent<SaveLoad>().m2++;
            GetComponent<SaveLoad>().SaveGame();
        }else if(!ss){
            GetComponent<SaveLoad>().m2--;
            GetComponent<SaveLoad>().SaveGame();
        }else{
            Debug.LogError("Ops! houve algum erro. Veja se o seguinte valor é false ou true: " + ss);
        }
    }
    public void SavePartner(){
        GetComponent<SaveLoad>().companheiro = true;
        GetComponent<SaveLoad>().SaveGame();
    }
    public void SaveMission(int id){
        GetComponent<SaveLoad>().missoes[id].missionActive = true;
    }
    public void SaveMissionAids(int id){
        GetComponent<SaveLoad>().missoes[id].aidsUsed++;
        GetComponent<SaveLoad>().SaveGame();
    }
    public void SaveMissionAidsItem(int id, int type){
        if (type == 0){
            GetComponent<SaveLoad>().missoes[id].tipsUsed = true;
            SaveMissionAids(id);
        }else if(type == 1){
            GetComponent<SaveLoad>().missoes[id].adviceUsed = true;
            SaveMissionAids(id);
        }else if(type == 2){
            GetComponent<SaveLoad>().missoes[id].m2Used = true;
            SaveMissionAids(id);
        }else{
            Debug.LogError("Ops! houve algum erro. Veja se o seguinte valor é 0, 1 ou 2: " + type);
        }
    }


    //          *** Funções para carregar os itens salvos   ***
    public void LoadPosition(){
        transform.position = new Vector2(
            GetComponent<SaveLoad>().posicao[0], GetComponent<SaveLoad>().posicao[1]
        );
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
        return GetComponent<SaveLoad>().recomen;
    }
    public int LoadMinus2(){
        return GetComponent<SaveLoad>().m2;
    }
    public bool LoadPartner(){
        return gameObject.GetComponent<SaveLoad>().companheiro;
    }
    public Mission LoadMission(int id){
        return GetComponent<SaveLoad>().missoes[id];
    }


    //  *** Funções para chamar valores dos itens a serem exibidos em textos ***
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
        //tipsTextUI.text = LoadTips().ToString();
        //adviceTextUI.text = LoadAdvices().ToString();
        //m2TextUI.text = LoadMinus2().ToString();
    }
    public void ItemsGUI(){
        lifesTextGUI.text = LoadLifes().ToString();
        coinsTextGUI.text = LoadCoins().ToString();
        tipsTextGUI.text = LoadTips().ToString();
        adviceTextGUI.text = LoadAdvices().ToString();
        m2TextGUI.text = LoadMinus2().ToString();
    }
}
