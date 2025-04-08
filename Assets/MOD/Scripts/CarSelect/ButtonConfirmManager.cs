using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonConfirmManager : MonoBehaviour
{
    public Button button1; // Ready P1
    public Button button2; // Ready P2
    public GameObject letsGo; // Let's Go
    public Button button3;

    public TMP_Text button1Text; 
    public TMP_Text button2Text; 

    public bool isButton1Ready = false; 
    public bool isButton2Ready = false; 


    void Start()
    {
        button1Text.text = "Pressione";
        button2Text.text = "Pressione";

 

        letsGo.gameObject.SetActive(false);

        button1.onClick.AddListener(() => OnButtonPressed(1));
        button2.onClick.AddListener(() => OnButtonPressed(2));
        button3.onClick.AddListener(OnConfirmPressed);
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

       
        if (isButton1Ready && isButton2Ready)
        {
            letsGo.gameObject.SetActive(true);
        }
    }

    void OnConfirmPressed()
    {
        SceneManager.LoadScene("Pista1MP");
    }
}
