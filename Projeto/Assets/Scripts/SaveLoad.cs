using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TreeEditor;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Save s = new Save();

        s.life = 3;
        s.score = 0;
        s.aid = 0;
        s.tips = 0;
        s.m2 = 0;
        s.partner = false;
        s.missions = new List<bool>
        {
            false, false, false, false, false, false, false, false, false
        };

        SaveGame(s);

        /*Save load = LoadGame();

        Debug.Log(
            "<color=red> Vida: </color>" + load.life + 
            "<color=yellow> Pontos: </color>" +  load.score + 
            "<color=blue> Ajudas: </color>" +  load.aid + 
            "<color=green> Dicas: </color>" + load.tips + 
            "<color=orange> -2: </color>" + load.m2 + 
            "<color=cyan> Companheiro: </color>" + s.partner
        );
        Debug.Log(
            "<color=black> Missões: </color>" +
            "<color=with> 0: </color>" + s.missions[0] + 
            "<color=with> 1: </color>" + s.missions[1] + 
            "<color=with> 2: </color>" + s.missions[2] + 
            "<color=with> 3: </color>" + s.missions[3] + 
            "<color=with> 4: </color>" + s.missions[4] + 
            "<color=with> 5: </color>" + s.missions[5] + 
            "<color=with> 6: </color>" + s.missions[6] + 
            "<color=with> 7: </color>" + s.missions[7] + 
            "<color=with> 8: </color>" + s.missions[8]);*/
    }

    public void SaveGame(Save s){
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
}
