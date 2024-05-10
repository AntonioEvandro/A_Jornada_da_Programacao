using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveLoad : MonoBehaviour
{
    [SerializeField]
    private float[] posicao = new float[2]{-16.5f,-0.75f};
    [SerializeField]
    private int vida = 3, pontos = 0, ajudas = 0, dicas = 0, mn2 = 0;
    private bool companheiro = false;
    [SerializeField]
    private List<bool> missoes = new(){false, false, false, false, false, false, false, false, false};

    // Start is called before the first frame update
    private void Start()
    {

        SaveGame();

        Save load = LoadGame();

        Logs(load);
    }

    public void SaveGame(){

        Save s = new()
        {
            position = posicao,
            life = vida,
            score = pontos,
            aid = ajudas,
            tips = dicas,
            m2 = mn2,
            partner = companheiro,
            missions = missoes
        };

        BinaryFormatter bf = new BinaryFormatter();

        string path = Application.persistentDataPath; //C:\Users\T-Gamer\AppData\LocalLow\DefaultCompany\Projeto
        FileStream file = File.Create(path + "/savegame.save");

        bf.Serialize(file, s);
        file.Close();

        Debug.Log("Jogo salvo com sucesso!!!");
    }

    public Save LoadGame(){
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath;

        FileStream file;

        if (File.Exists(path + "/savegame.save")){
            file = File.Open(path + "/savegame.save", FileMode.Open);
            Save load = (Save)bf.Deserialize(file);

            Debug.Log("Jogo carregado!!!");

            return load;
        }

        return null;
    }

    public void Logs(Save load){
        Debug.Log(
            "<color=gray> Posição: </color>" + load.position[0] + "." + load.position[1] +
            "<color=red> Vida: </color>" + load.life + 
            "<color=yellow> Pontos: </color>" +  load.score + 
            "<color=blue> Ajudas: </color>" +  load.aid + 
            "<color=green> Dicas: </color>" + load.tips + 
            "<color=orange> -2: </color>" + load.m2 + 
            "<color=cyan> Companheiro: </color>" + load.partner
        );
        Debug.Log(
            "<color=black> Missões: </color>" +
            "<color=with> 0: </color>" + load.missions[0] + 
            "<color=with> 1: </color>" + load.missions[1] + 
            "<color=with> 2: </color>" + load.missions[2] + 
            "<color=with> 3: </color>" + load.missions[3] + 
            "<color=with> 4: </color>" + load.missions[4] + 
            "<color=with> 5: </color>" + load.missions[5] + 
            "<color=with> 6: </color>" + load.missions[6] + 
            "<color=with> 7: </color>" + load.missions[7] + 
            "<color=with> 8: </color>" + load.missions[8]
        );}

    public void Update(){
        posicao = new float[2]{transform.position.x, transform.position.y};
        //
    }
}
