using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class SaveLoad : MonoBehaviour
{
    [SerializeField] private string newGame;
    private int x;
    private readonly int tam = 9;
    public List<float> posicao;
    public int vidas, moedas, recomen, dicas, m2;
    public bool companheiro;
    public List<Mission> missoes;

    // Start is called before the first frame update
    private void Start()
    {
        Save l = LoadGame();
        LoadLogs(l);
    }


    public void SaveGame(){
        Save s = new()
        {
            position = posicao,
            life = vidas,
            coins = moedas,
            advices = recomen,
            tips = dicas,
            m2 = m2,
            partner = companheiro,
            missions = missoes
        };

        BinaryFormatter bf = new();

        string path = Path.Combine(Application.persistentDataPath + "/savegame.save"); //C:\Users\T-Gamer\AppData\LocalLow\DefaultCompany\Projeto
        
        if (File.Exists(path)){
            //Debug.Log("" + path);
            File.WriteAllText(path, string.Empty);
            //Debug.Log("Arquivo limpo!");
        }
        else{
            FileStream f = File.Create(path);
            f.Dispose();
            //Debug.Log("Arquivo criado!");
        }
        
        FileStream file = new(path, FileMode.Append);
        //Debug.Log("Acrescentado");

        bf.Serialize(file, s);
        file.Close();

        Debug.Log("<color=green>Jogo salvo com sucesso!!!</color>");
    }

    //  Função que carrega os dados do arquivo save
    public Save LoadGame(){
        //Debug.Log("bf add");  //Variavel bf com formato binário definido
        BinaryFormatter bf = new BinaryFormatter();
        //Debug.Log("path add");    //Caminho do arquivo de dados salvos adicionado a váriavel path
        string path = Application.persistentDataPath;
        
        //Debug.Log("Create file"); //Criando a variável file para receber dados do arquivo de dados salvos
        FileStream file;

        //Verificando se já existe dados de salvamento anteriores
        if (File.Exists(path + "/savegame.save")){
            //Debug.Log("Open save"); //Abrindo arquivo de dados salvos e copiando para a variavel file
            file = File.Open(path + "/savegame.save", FileMode.Open);
            
            //Debug.Log("Create load"); //Variavel load tipo save criada para receber os dados de file 
            Save load = new();
            //load recebe dados de file tornando-os legivel para leitura posterior
            load = (Save)bf.Deserialize(file);

            Debug.Log("<color=orange>Jogo carregado!!!</color>");
            //Debug.Log("Closed file"); //Arquivo fechado. Evitando erro terrível.
            file.Close();

            //Armazenando valores nas variáveis
            posicao = load.position;
            //Pegando posição do player salvo no arquivo save e adicionando a ele
            GetComponent<Items>().LoadPosition();
            
            vidas = load.life;
            moedas = load.coins;
            recomen = load.advices;
            dicas = load.tips;
            m2 = load.m2;
            companheiro = load.partner;
            //missoes = new(){null,null,null,null,null,null,null,null,null,null};
            missoes = load.missions;
            //Debug.Log("missao " + load.missions[0].id + ", " + load.missions[0].missionActive);

            //enviando a variavel load para uso externo
            return load;
        }

        return null;
    }

    //Função teste criada para carregar dados salvos, usa-se através do botão carregar no jogo.
    public void BtnCarregar(bool car){
        if (car){
            Save l = LoadGame();
            LoadLogs(l);
            BtnCarregar(false);
        }
    }

    //Reiniciar o jogo
    public void TryAgain(){
        posicao = new(){-16.5f,-0.75f};
        vidas = 3;
        moedas = 0;
        recomen = 0;
        dicas = 0;
        m2 = 0;
        companheiro = false;
        for(x = 0; x < tam; x++){
            Mission aux = new(){
                id = x,
                missionActive = false,
                aidsUsed = 0,
                adviceUsed = false,
                tipsUsed = false,
                m2Used = false,
            };
            missoes[x] = aux;
        }
        SaveGame();
        SceneManager.LoadScene(newGame);
    }

    //Todos os logs de carregamento do arquivo de dados salvos
    public void LoadLogs(Save load){
        Debug.Log(
            "<color=gray> Posição: </color>" + load.position[0] + "." + load.position[1] +
            "<color=red> Vida: </color>" + load.life + 
            "<color=yellow> Pontos: </color>" +  load.coins + 
            "<color=blue> Ajudas: </color>" +  load.advices + 
            "<color=green> Dicas: </color>" + load.tips + 
            "<color=orange> -2: </color>" + load.m2 + 
            "<color=cyan> Companheiro: </color>" + load.partner
        );
        Debug.Log("<color=black> Missões: </color>");
        for(x=0; x<tam; x++){
            Debug.Log("<color=with> Missão " + load.missions[x].id + "</color> completa: " + load.missions[x].missionActive + ", Ajudas usadas: " + load.missions[x].aidsUsed + ", recomendação: " + load.missions[x].adviceUsed + ", dica: " + load.missions[x].tipsUsed + ", menos 2: " + load.missions[x].m2Used);
        }
    }
}
