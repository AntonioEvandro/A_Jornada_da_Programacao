using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
{
    public GameObject items;
    public void BuyLyfe(){
        if (items.GetComponent<Items>().LoadCoins()>= 10){
            items.GetComponent<Items>().SaveLifes(true);
            Debug.Log("<color=Green>Vida adquirida com sucesso!</color> Total: <color=red>" + items.GetComponent<Items>().LoadLifes() + "</color>. Saldo: <color=yellow>" + items.GetComponent<Items>().LoadCoins() + "</color>");
        }else{
            NoCoins();
        }
    }
    public void BuyTip(){
        if(items.GetComponent<Items>().LoadCoins() >= 10){
            items.GetComponent<Items>().SaveTips(true);
            Debug.Log("<color=Green>Dica adquirida com sucesso!</color> Total: <color=red>" + items.GetComponent<Items>().LoadTips() + "</color>. Saldo: <color=yellow>" + items.GetComponent<Items>().LoadCoins() + "</color>");
        }else{
            NoCoins();
        }
    }
    public void BuyAdvice(){
        if(items.GetComponent<Items>().LoadCoins() >= 10){
            items.GetComponent<Items>().SaveAdvices(true);
            Debug.Log("<color=Green>Recomendação adquirida com sucesso!</color> Total: <color=red>" + items.GetComponent<Items>().LoadAdvices() + "</color>. Saldo: <color=yellow>" + items.GetComponent<Items>().LoadCoins() + "</color>");
        }else{
            NoCoins();
        }
    }
    public void BuyM2(){
        if(items.GetComponent<Items>().LoadCoins() >= 10){
            items.GetComponent<Items>().SaveMinus2(true);
            Debug.Log("<color=Green>Menos duas adquirida com sucesso!</color> Total: <color=red>" + items.GetComponent<Items>().LoadMinus2() + "</color>. Saldo: <color=yellow>" + items.GetComponent<Items>().LoadCoins() + "</color>");
        }else{
            NoCoins();
        }
    }
    public void NoCoins(){
        Debug.Log("<color=red> Moedas insuficientes! </color> Seu saldo é: <color=Orange>" + items.GetComponent<Items>().LoadCoins() + "</color>");
    }
}
