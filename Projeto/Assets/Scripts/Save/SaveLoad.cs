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
    public List<float> posiCompa;
    public int vidas, moedas, recomen, dicas, m2;
    public bool companheiro, ilha, mercado;
    public List<Mission> missoes;
    public bool[] dialogos;

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
            partnerPosit = posiCompa,
            life = vidas,
            coins = moedas,
            advices = recomen,
            tips = dicas,
            m2 = m2,
            partner = companheiro,
            island = ilha,
            market = mercado,
            missions = missoes,
            dialogue = dialogos
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

            Debug.Log("<size=25><color=Blue><b> Jogo carregado!!! </b></color></size>");
            //Debug.Log("Closed file"); //Arquivo fechado. Evitando erro terrível.
            file.Close();

            //Armazenando valores nas variáveis
            posicao = load.position;
            //Pegando posição do player salvo no arquivo save e adicionando a ele
            GetComponent<Items>().LoadPosition();
            posiCompa = load.partnerPosit;
            GetComponent<Items>().LoadPartnerPosition();
            
            vidas = load.life;
            moedas = load.coins;
            recomen = load.advices;
            dicas = load.tips;
            m2 = load.m2;
            companheiro = load.partner;
            ilha = load.island;
            //missoes = new(){null,null,null,null,null,null,null,null,null,null};
            missoes = load.missions;
            //Debug.Log("missao " + load.missions[0].id + ", " + load.missions[0].missionActive);
            dialogos = load.dialogue;

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
        posiCompa = new(){-11.5f,0};
        vidas = 3;
        moedas = 0;
        recomen = 0;
        dicas = 0;
        m2 = 0;
        companheiro = false;
        ilha = false;
        mercado = false;
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
        dialogos = new bool[tam*3];
        for(x = 0; x < tam*3-1; x++){
            dialogos[x] = false;
        }
        SaveGame();
        SceneManager.LoadScene(newGame);
    }

    //Todos os logs de carregamento do arquivo de dados salvos
    public void LoadLogs(Save load){
        Debug.LogFormat("<color=#519DDA> Posição </color><b>X:</b> {0} <b>Y:</b> {1} <color=red> Vida: </color> {2}<color=yellow> Pontos: </color> {3}\n<color=orange> Recomendações: </color> {4}<color=green> Dicas: </color> {5}<color=purple> Menos dois: </color>{6}<color=cyan> Companheiro: </color>{7}<color=#7fffd4> Ilha 2ªpt: </color>{8}<color=#8b0000> Mercado: </color>{9}", load.position[0].ToString("F2"), load.position[1].ToString("F2"), load.life, load.coins, load.advices, load.tips, load.m2, load.partner, load.island, load.market);

        print("<size=23><color=Grey> Missões: </color></size>");
        for(x=0; x<tam; x++){
            Debug.Log("<color=with> Missão " + load.missions[x].id + "</color> completa: " + load.missions[x].missionActive + ", Ajudas usadas: " + load.missions[x].aidsUsed + ",\n recomendação: " + load.missions[x].adviceUsed + ", dica: " + load.missions[x].tipsUsed + ", menos duas opções: " + load.missions[x].m2Used);
        }
        Debug.LogFormat("<color=black><size=14> Diálogos exibidos </size></color> <color=with> 01:</color> {0} <color=with>02:</color> {1} <color=with>03:</color> {2} <color=with>04:</color> {3} <color=with>05:</color> {4} <color=with>06:</color> {5} <color=with>07:</color> {6}\n <color=with>08:</color> {7} <color=with>09:</color> {8} <color=with>10:</color> {9} <color=with>11:</color> {10} <color=with>12:</color> {11} <color=with>13:</color> {12} <color=with>14:</color> {13} <color=with>15:</color> {14} <color=with>16:</color> {15} <color=with>17:</color> {16}\n <color=with>18:</color> {17} <color=with>19:</color> {18} <color=with>20:</color> {19} <color=with>21:</color> {20} <color=with>22:</color> {21} <color=with>23:</color> {22} <color=with>24:</color> {23} <color=with>25:</color> {24} <color=with>26:</color> {25} <color=with>27:</color> {26}\n ", load.dialogue[0], load.dialogue[1], load.dialogue[2], load.dialogue[3], load.dialogue[4], load.dialogue[5],load.dialogue[6],load.dialogue[7],load.dialogue[8],load.dialogue[9],load.dialogue[10],load.dialogue[11],load.dialogue[12],load.dialogue[13],load.dialogue[14],load.dialogue[15],load.dialogue[16],load.dialogue[17],load.dialogue[18],load.dialogue[19],load.dialogue[20],load.dialogue[21],load.dialogue[22],load.dialogue[23],load.dialogue[24],load.dialogue[25],load.dialogue[26]);
    }
}
