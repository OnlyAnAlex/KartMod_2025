using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeMagnitude = 0.1f; // Intensidade do shake
    public float shakeSpeed = 1.0f; // Velocidade do shake

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.localPosition;
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        while (true)
        {
            float x = Mathf.PerlinNoise(Time.time * shakeSpeed, 0) * 2 - 1;
            float y = Mathf.PerlinNoise(0, Time.time * shakeSpeed) * 2 - 1;

            transform.localPosition = initialPosition + new Vector3(x, y, 0) * shakeMagnitude;

            yield return null;
        }
    }
}
