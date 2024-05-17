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
    public float[] posicao;
    public int vidas, moedas, ajudas, dicas, m2;
    public bool companheiro;
    public List<bool> missoes;

    // Start is called before the first frame update
    private void Start()
    {

        Save load = LoadGame();
        LoadLogs(load);
    }

    void Update()
    {
        //Atualiza a váriavel posição com os dados de localização do player para salvar onde o player esteve anteriormente
        //posicao = new float[2]{transform.position.x, transform.position.y};
    }


    public void SaveGame(){

        Save s = new()
        {
            position = posicao,
            life = vidas,
            coins = moedas,
            advice = ajudas,
            tips = dicas,
            m2 = m2,
            partner = companheiro,
            missions = missoes
        };


        BinaryFormatter bf = new();

        string path = Path.Combine(Application.persistentDataPath + "/savegame.save"); //C:\Users\T-Gamer\AppData\LocalLow\DefaultCompany\Projeto

        //Debug.Log("Arquivo existe" + File.Exists(path));
        
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

            //Pegando posição do player salvo no arquivo save e adicionando a ele
            transform.position = new Vector2(load.position[0],load.position[1]);
            //Armazenando valores nas variáveis
            vidas = load.life;
            moedas = load.coins;
            ajudas = load.advice;
            dicas = load.tips;
            m2 = load.m2;
            companheiro = load.partner;
            missoes = load.missions;
            Debug.Log("posicão" + posicao[0] + ", " + posicao[1]);

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
    //Todos os logs de carregamento do arquivo de dados salvos
    public void LoadLogs(Save load){
        Debug.Log(
            "<color=gray> Posição: </color>" + load.position[0] + "." + load.position[1] +
            "<color=red> Vida: </color>" + load.life + 
            "<color=yellow> Pontos: </color>" +  load.coins + 
            "<color=blue> Ajudas: </color>" +  load.advice + 
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
    
    //Reiniciar o jogo
    public void TryAgain(){
        posicao = new float[2]{-16.5f,-0.75f};
        vidas = 3;
        moedas = 0;
        ajudas = 0;
        dicas = 0;
        m2 = 0;
        companheiro = false;
        missoes = new(){false, false, false, false, false, false, false, false, false};
        SaveGame();
        SceneManager.LoadScene(newGame);
    }
    /*
    //Salvar/Carregar dados do jogo
    public void SalvarMoedas(int pts){
        moedas += pts;
        SaveGame();
    }
    public int CarregarMoedas(){
        return moedas;
    }
    public void SalvarVidas(int vds) {
        vidas = vds;
        SaveGame();
    }
    public int CarregarVidas() {
        return vidas;
    }
    public void SalvarMissao(int mis){
        missoes[mis] = true;
    }
    public bool CarregarMissao(int n){
        return missoes[n];
    }*/
}
