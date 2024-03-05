using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Transform pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializa o menu de pausa como inativo
        pauseMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu(); // Chama a função quando a tecla "Escape" é pressionada
        }
    }

    // Função chamada pelo botão "Continuar"
    public void OnContinueButtonClicked()
    {
        TogglePauseMenu(); // Chama a mesma função para continuar o jogo
    }

    // Função para alternar a visibilidade do menu de pausa
    void TogglePauseMenu()
    {
        bool isMenuActive = pauseMenu.gameObject.activeSelf;

        // Alterna o menu de pausa e ajusta o time scale conforme necessário
        pauseMenu.gameObject.SetActive(!isMenuActive);
        Time.timeScale = isMenuActive ? 1f : 0f;
    }
}
