using UnityEngine;

public class CarAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 finalPosition;
        private Vector3 initialPosition;

    public float velocidadeRotacao = 50f;

    private void Awake()
    {
        initialPosition = transform.position;

    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, finalPosition, 0.1f);
        transform.Rotate(0, velocidadeRotacao * Time.deltaTime, 0);
    }

    private void OnDisable()
    {
        transform.position = initialPosition;
    }

   

  
}
