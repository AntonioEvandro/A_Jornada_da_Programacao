using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Save s = new Save();

        s.score = 0;
        s.aid = 0;
        s.tips = 0;
        s.m2 = 0;
        s.partner = false;
        s.missions = new List<bool>
        {
            false, false, false, false, false, false, false, false
        };

        SaveGame(s);

        Save load = LoadGame();

        Debug.Log(load.missions[0]);
    }

    public void SaveGame(Save s){
        BinaryFormatter bf = new BinaryFormatter();

        string path = Application.persistentDataPath; //AppData/LocalLow/SeuNome
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
