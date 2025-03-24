using UnityEngine;
using UnityEngine.UI;

public class SwingImage : MonoBehaviour
{
    // Refer�ncia para a imagem
    private RectTransform rectTransform;

    // Amplitude e velocidade do balan�o
    public float amplitude = 10f;
    public float speed = 2f;

    // Posi��o inicial
    private Vector3 initialPosition;

    void Start()
    {
        // Obt�m o RectTransform do GameObject ao qual o script est� anexado
        rectTransform = GetComponent<RectTransform>();

        // Armazena a posi��o inicial para garantir que o balan�o seja feito em torno dela
        initialPosition = rectTransform.localPosition;
    }

    void Update()
    {
        // Calcula a posi��o oscilante usando a fun��o seno
        float offset = Mathf.Sin(Time.time * speed) * amplitude;

        // Aplica o offset � posi��o inicial
        rectTransform.localPosition = initialPosition + new Vector3(offset, 0f, 0f);
    }
}
