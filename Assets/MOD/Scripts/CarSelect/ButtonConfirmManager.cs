using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonConfirmManager : MonoBehaviour
{
    public Button button1; // Botão 1
    public Button button2; // Botão 2
    public Button confirmButton; // Botão de confirmação
    public TMP_Text button1Text; // Texto do botão 1
    public TMP_Text button2Text; // Texto do botão 2

    private bool isButton1Ready = false; // Estado do botão 1
    private bool isButton2Ready = false; // Estado do botão 2

    // Variáveis a serem enviadas
    private int variableA = 42;
    private string variableB = "Olá, próxima cena!";

    void Start()
    {
        // Inicializa o texto dos botões
        button1Text.text = "Pressione";
        button2Text.text = "Pressione";

        // Desativa o botão de confirmação inicialmente
        confirmButton.gameObject.SetActive(false);

        // Adiciona os listeners dos botões
        button1.onClick.AddListener(() => OnButtonPressed(1));
        button2.onClick.AddListener(() => OnButtonPressed(2));
        confirmButton.onClick.AddListener(OnConfirmPressed);
    }

    void OnButtonPressed(int buttonNumber)
    {
        if (buttonNumber == 1 && !isButton1Ready)
        {
            isButton1Ready = true;
            button1Text.text = "PRONTO!";
        }
        else if (buttonNumber == 2 && !isButton2Ready)
        {
            isButton2Ready = true;
            button2Text.text = "PRONTO!";
        }

        // Verifica se ambos estão prontos
        if (isButton1Ready && isButton2Ready)
        {
            confirmButton.gameObject.SetActive(true);
        }
    }

    void OnConfirmPressed()
    {
        // Envia as variáveis para a próxima cena
        PlayerPrefs.SetInt("VariableA", variableA);
        PlayerPrefs.SetString("VariableB", variableB);

        // Troca para a nova cena
        SceneManager.LoadScene("NovaCena");
    }
}
