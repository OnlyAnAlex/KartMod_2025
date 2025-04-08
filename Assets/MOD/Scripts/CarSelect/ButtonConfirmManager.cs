using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonConfirmManager : MonoBehaviour
{
    public Button button1; // Bot�o 1
    public Button button2; // Bot�o 2
    public Button confirmButton; // Bot�o de confirma��o
    public TMP_Text button1Text; // Texto do bot�o 1
    public TMP_Text button2Text; // Texto do bot�o 2

    private bool isButton1Ready = false; // Estado do bot�o 1
    private bool isButton2Ready = false; // Estado do bot�o 2

    // Vari�veis a serem enviadas
    private int variableA = 42;
    private string variableB = "Ol�, pr�xima cena!";

    void Start()
    {
        // Inicializa o texto dos bot�es
        button1Text.text = "Pressione";
        button2Text.text = "Pressione";

        // Desativa o bot�o de confirma��o inicialmente
        confirmButton.gameObject.SetActive(false);

        // Adiciona os listeners dos bot�es
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

        // Verifica se ambos est�o prontos
        if (isButton1Ready && isButton2Ready)
        {
            confirmButton.gameObject.SetActive(true);
        }
    }

    void OnConfirmPressed()
    {
        // Envia as vari�veis para a pr�xima cena
        PlayerPrefs.SetInt("VariableA", variableA);
        PlayerPrefs.SetString("VariableB", variableB);

        // Troca para a nova cena
        SceneManager.LoadScene("NovaCena");
    }
}
