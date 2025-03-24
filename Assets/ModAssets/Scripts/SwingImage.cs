using UnityEngine;
using UnityEngine.UI;

public class SwingImage : MonoBehaviour
{
    // Referência para a imagem
    private RectTransform rectTransform;

    // Amplitude e velocidade do balanço
    public float amplitude = 10f;
    public float speed = 2f;

    // Posição inicial
    private Vector3 initialPosition;

    void Start()
    {
        // Obtém o RectTransform do GameObject ao qual o script está anexado
        rectTransform = GetComponent<RectTransform>();

        // Armazena a posição inicial para garantir que o balanço seja feito em torno dela
        initialPosition = rectTransform.localPosition;
    }

    void Update()
    {
        // Calcula a posição oscilante usando a função seno
        float offset = Mathf.Sin(Time.time * speed) * amplitude;

        // Aplica o offset à posição inicial
        rectTransform.localPosition = initialPosition + new Vector3(offset, 0f, 0f);
    }
}
